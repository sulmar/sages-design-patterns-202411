using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Models.FiniteStateMachine;

// dotnet add package stateless

public class LightSwitch 
{
    public virtual LightSwitchState State { get; set; }

    public LightSwitch()
    {
        State = LightSwitchState.Off;
    }

    public virtual void Push() {

        if (State == LightSwitchState.Off)
        {
            Console.WriteLine("załącz przekaźnik");

            State = LightSwitchState.On;
            return;
        }

        if (State == LightSwitchState.On)
        {
            Console.WriteLine("wyłącz przekaźnik");

            State = LightSwitchState.Off;
            return;
        }

    }
}

public enum LightSwitchState
{
    On,
    Off,
    Medium
}

public enum LightSwitchTrigger
{
    Push
}