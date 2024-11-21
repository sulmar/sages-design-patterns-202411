using Stateless;
using System;

namespace StatePattern.Models.FiniteStateMachine;

// Factory
public class LightSwitchStateMachineFactory
{
    public StateMachine<LightSwitchState, LightSwitchTrigger> Create(string model)
    {
        switch(model)
        {
            case "abc": return new AbcStateMachine();
            case "xyz": return new AbcStateMachine();

            default: throw new NotSupportedException();
        }
    }
}
