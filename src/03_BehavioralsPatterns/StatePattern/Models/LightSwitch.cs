using System;

namespace StatePattern;

// Abstract State
public abstract class LightSwitchState
{
    protected readonly LightSwitch lightSwitch;

    protected LightSwitchState(LightSwitch lightSwitch)
    {
        this.lightSwitch = lightSwitch;
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

        lightSwitch.State = new On(lightSwitch);
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

        lightSwitch.State = new Off(lightSwitch);   
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

        lightSwitch.State = new Medium(lightSwitch);
    }
}

public class LightSwitch
{
    public LightSwitchState State { get; set; }

    public LightSwitch()
    {
        State = new Off(this);
    }

    public void Push()
    {
        State.Push();
    }
}


