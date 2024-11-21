using System;
using System.Collections.Generic;

namespace StatePattern;

// Abstract State
public abstract class LightSwitchState : ICloneable
{
    protected readonly LightSwitch lightSwitch;

    protected LightSwitchState(LightSwitch lightSwitch)
    {
        this.lightSwitch = lightSwitch;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    // Handle
    public abstract void Push();
}

// Concrete State
public class Off : LightSwitchState
{
    public Off(LightSwitch lightSwitch) : base(lightSwitch)
    {
    }

    public override void Push()
    {
        Console.WriteLine("załącz przekaźnik");

        lightSwitch.SetState(new Medium(lightSwitch));
    }
}

public class Medium : LightSwitchState
{
    public Medium(LightSwitch lightSwitch) : base(lightSwitch)
    {
    }

    public override void Push()
    {
        Console.WriteLine("przygaś na 50%");

        if (lightSwitch.PreviousState is Off)
            lightSwitch.SetState(new On(lightSwitch));   

        else if (lightSwitch.PreviousState is On)
            lightSwitch.SetState(new Off(lightSwitch));
    }
}


public class On : LightSwitchState
{
    public On(LightSwitch lightSwitch) : base(lightSwitch)
    {
    }

    public override void Push()
    {
        Console.WriteLine("wyłącz przekaźnik");

        lightSwitch.SetState(new Medium(lightSwitch));
    }
}

public class LightSwitch
{
    public LightSwitchState State { get; private set; }
    public LightSwitchState PreviousState => History.Peek();

   // public LightSwitchState PreviousState { get; private set; }

    public Stack<LightSwitchState> History { get; set; } = [];

    public void SetState(LightSwitchState newState)
    {
        var tempState = State?.Clone() as LightSwitchState;

        State = newState;

        if (tempState != null)
        {
            History.Push(tempState);
        }
    }

    public LightSwitch()
    {
        SetState(new Off(this));
    }

    public void Push()
    {
        State.Push();
    }
}


