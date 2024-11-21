using Stateless;
using System;

namespace StatePattern.Models.FiniteStateMachine;

// Strategia
public class AbcStateMachine : StateMachine<LightSwitchState, LightSwitchTrigger>
{
    public AbcStateMachine() : base(LightSwitchState.Off)
    {
        this.Configure(LightSwitchState.Off)
         .OnEntry(() => Console.WriteLine("wyłącz przekaźnik"), "Wyłączprzekaźnik")
         .Permit(LightSwitchTrigger.Push, LightSwitchState.Medium);

        this.Configure(LightSwitchState.Medium)
            .Permit(LightSwitchTrigger.Push, LightSwitchState.On);

        this.Configure(LightSwitchState.On)
            .OnEntry(() => Console.WriteLine("załącz przekaźnik"), "załączprzekaźnik")
            .Permit(LightSwitchTrigger.Push, LightSwitchState.Off);

        this.OnTransitioned(t => Console.WriteLine($"{t.Trigger} : {t.Source} -> {t.Destination} "));
    }
}
