using Stateless;
using System;

namespace StatePattern.Models.FiniteStateMachine;

// Factory
public class LightSwitchStateMachineFactory
{
    private readonly IRelayService relayService;
    private readonly IMessageService messageService;

    public LightSwitchStateMachineFactory(IRelayService relayService, IMessageService messageService)
    {
        this.relayService = relayService;
        this.messageService = messageService;
    }

    public StateMachine<LightSwitchState, LightSwitchTrigger> Create(string model)
    {
        switch (model)
        {
            case "abc": return new AbcStateMachine(relayService, messageService);
            case "xyz": return new AbcStateMachine(relayService, messageService);

            default: throw new NotSupportedException();
        }
    }
}
