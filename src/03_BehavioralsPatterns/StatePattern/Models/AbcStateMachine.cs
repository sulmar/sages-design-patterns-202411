using Stateless;
using System;

namespace StatePattern.Models.FiniteStateMachine;

public interface IRelayService
{
    void Enable(byte id);
    void Disable(byte id);
}

public interface IMessageService
{
    void Send(string message);
}

public class FakeRelayService : IRelayService
{
    private bool enabled = false;
    public void Disable(byte id) => enabled = false;
    public void Enable(byte id) => enabled = true;
}

public class FakeMessageService : IMessageService
{
    public void Send(string message) => Console.WriteLine($"Send by email {message}");
}

// Strategia
public class AbcStateMachine : StateMachine<LightSwitchState, LightSwitchTrigger>
{
    private readonly IRelayService relayService;
    private readonly IMessageService messageService;

    public AbcStateMachine(IRelayService relayService, IMessageService messageService) : base(LightSwitchState.Off)
    {
        this.relayService = relayService;
        this.messageService = messageService;

        this.Configure(LightSwitchState.Off)
          .OnEntry(() => relayService.Disable(1))
          .OnEntry(() => messageService.Send("wyłącz przekaźnik"), "Wyłączprzekaźnik")
          .Permit(LightSwitchTrigger.Push, LightSwitchState.Medium);

        this.Configure(LightSwitchState.Medium)
            .Permit(LightSwitchTrigger.Push, LightSwitchState.On);

        this.Configure(LightSwitchState.On)
            .OnEntry(() => relayService.Enable(1))
            .OnEntry(() => messageService.Send("załącz przekaźnik"), "załączprzekaźnik")
            .Permit(LightSwitchTrigger.Push, LightSwitchState.Off);

        this.OnTransitioned(t => Console.WriteLine($"{t.Trigger} : {t.Source} -> {t.Destination} "));
        this.relayService = relayService;
        this.messageService = messageService;
    }
}
