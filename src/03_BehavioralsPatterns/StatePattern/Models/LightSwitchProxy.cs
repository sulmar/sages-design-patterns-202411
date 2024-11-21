using Stateless;

namespace StatePattern.Models.FiniteStateMachine;

// Proxy - wariant klasowy
public class LightSwitchProxy : LightSwitch
{
    private readonly StateMachine<LightSwitchState, LightSwitchTrigger> _machine;

    public LightSwitchProxy(StateMachine<LightSwitchState, LightSwitchTrigger> machine)
    {
        this._machine = machine;
       
        // _machine.OnTransitioned(t => history.Push(t));
    }

    public override LightSwitchState State => _machine.State;
    public virtual void Push() => _machine.Fire(LightSwitchTrigger.Push);

    public string Graph => Stateless.Graph.UmlDotGraph.Format(_machine.GetInfo());

    
}
