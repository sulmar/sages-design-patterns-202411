using Stateless;
using System;

namespace StatePattern.Models.FiniteStateMachine;

// Factory
public class LightSwitchStateMachineFactory
{
    private readonly IMediator mediator;

    public LightSwitchStateMachineFactory(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public StateMachine<LightSwitchState, LightSwitchTrigger> Create(string model)
    {
        switch (model)
        {
            case "abc": return new AbcStateMachine(mediator);
            case "xyz": return new AbcStateMachine(mediator);

            default: throw new NotSupportedException();
        }
    }
}
