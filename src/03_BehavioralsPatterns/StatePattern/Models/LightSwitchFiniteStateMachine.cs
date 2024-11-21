using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Models.FiniteStateMachine;

public interface ILightSwitch
{
    LightSwitchState State { get; set; }
    void Push();
}

// Proxy - wariant klasowy
public class LightSwitchProxy : LightSwitch
{
    private readonly StateMachine<LightSwitchState, LightSwitchTrigger> _machine;

    public LightSwitchProxy()
    {
        _machine = new StateMachine<LightSwitchState, LightSwitchTrigger>(LightSwitchState.Off);

        _machine.Configure(LightSwitchState.Off)
            .OnEntry(() => Console.WriteLine("wyłącz przekaźnik"), "Wyłączprzekaźnik")
            .Permit(LightSwitchTrigger.Push, LightSwitchState.Medium);

        _machine.Configure(LightSwitchState.Medium)
            .Permit(LightSwitchTrigger.Push, LightSwitchState.On);

        _machine.Configure(LightSwitchState.On)
            .OnEntry(() => Console.WriteLine("załącz przekaźnik"), "załączprzekaźnik")
            .Permit(LightSwitchTrigger.Push, LightSwitchState.Off);

        _machine.OnTransitioned(t => Console.WriteLine($"{t.Trigger} : {t.Source} -> {t.Destination} "));

        // _machine.OnTransitioned(t => history.Push(t));
    }
    // private readonly Stack<Transaction> history = [];

    public string Graph => Stateless.Graph.UmlDotGraph.Format(_machine.GetInfo());

    public virtual void Push() => _machine.Fire(LightSwitchTrigger.Push);
}

// dotnet add package stateless

public class LightSwitch : ILightSwitch
{
    public virtual LightSwitchState State { get; set; }

    public LightSwitch()
    {
        State = LightSwitchState.Off;
    }

    public virtual void Push() {

       

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