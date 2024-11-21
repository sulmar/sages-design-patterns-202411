using Stateless;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StatePattern.Models.FiniteStateMachine;

// Abstract Mediator
public interface IMediator
{
    void NotifyLightSwitchState(LightSwitchState state);
    void Register(IColleague colleague);
}

// Concrete Mediator
public class Mediator : IMediator
{
    private List<IColleague> colleagies = [];
    public void Register(IColleague colleague)
    {
        colleagies.Add(colleague);
    }

    public void NotifyLightSwitchState(LightSwitchState state)
    {
        foreach (var colleague in colleagies)
        {
            colleague.NotifyLightSwitchState(state);
        }
    }    
}

// Abstract Colleague
public interface IColleague
{
    // Notify
    void NotifyLightSwitchState(LightSwitchState state);
}


public interface IRelayService : IColleague
{
    void Enable(byte id);
    void Disable(byte id);
}

public interface IMessageService : IColleague
{
    void Send(string message);
}

public class FakeRelayService : IRelayService
{
    private bool enabled = false;
    public void Disable(byte id) => enabled = false;
    public void Enable(byte id) => enabled = true;

    public void NotifyLightSwitchState(LightSwitchState state)
    {
        if (state == LightSwitchState.On)
        {
            Enable(1);
        }

        else
        {
            Disable(1);
        }
    }
}

public class FakeMessageService : IMessageService
{
    public void NotifyLightSwitchState(LightSwitchState state)
    {
        if (state == LightSwitchState.Off)
        {
            Send("wyłącz przekaźnik");
        }

        if (state == LightSwitchState.On)
        {
            Send("załącz przekaźnik");
        }
    }


    public void Send(string message) => Console.WriteLine($"Send by email {message}");
}

// Strategia
public class AbcStateMachine : StateMachine<LightSwitchState, LightSwitchTrigger>
{
    public AbcStateMachine(IMediator mediator) : base(LightSwitchState.Off)
    {
        this.Configure(LightSwitchState.Off)
          .OnEntry(() => mediator.NotifyLightSwitchState(LightSwitchState.Off))
          .Permit(LightSwitchTrigger.Push, LightSwitchState.Medium);

        this.Configure(LightSwitchState.Medium)
            .Permit(LightSwitchTrigger.Push, LightSwitchState.On);

        this.Configure(LightSwitchState.On)
            .OnEntry(() => mediator.NotifyLightSwitchState(LightSwitchState.On))
            .Permit(LightSwitchTrigger.Push, LightSwitchState.Off);

        this.OnTransitioned(t => Console.WriteLine($"{t.Trigger} : {t.Source} -> {t.Destination} "));
    }
}
