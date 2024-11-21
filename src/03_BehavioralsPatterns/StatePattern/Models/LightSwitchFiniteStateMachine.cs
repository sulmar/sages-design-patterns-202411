using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Models.FiniteStateMachine;


// dotnet add package stateless

public class LightSwitch
{
    public LightSwitchState State => _machine.State;

    private readonly StateMachine<LightSwitchState, LightSwitchTrigger> _machine;

    public LightSwitch()
    {
        _machine = new StateMachine<LightSwitchState, LightSwitchTrigger>(LightSwitchState.Off);

        _machine.Configure(LightSwitchState.Off)
            .OnEntry(() => Console.WriteLine("wyłącz przekaźnik"))
            .Permit(LightSwitchTrigger.Push, LightSwitchState.On);

        _machine.Configure(LightSwitchState.On)
            .OnEntry(() => Console.WriteLine("załącz przekaźnik"))
            .Permit(LightSwitchTrigger.Push, LightSwitchState.Off);
    }

    public void Push() => _machine.Fire(LightSwitchTrigger.Push);
}

public enum LightSwitchState
{
    On,
    Off
}

public enum LightSwitchTrigger
{
    Push
}