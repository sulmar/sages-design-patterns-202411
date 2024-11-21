using MediatR;
using StatePattern.Events;
using StatePattern.Models.FiniteStateMachine;
using System.Threading;
using System.Threading.Tasks;

namespace StatePattern.Handlers;

public class OnRelayHandler : INotificationHandler<OnEvent>
{
    private readonly IRelayService relayService;

    public OnRelayHandler(IRelayService relayService)
    {
        this.relayService = relayService;
    }

    public Task Handle(OnEvent notification, CancellationToken cancellationToken)
    {
        relayService.Enable(1);

        return Task.CompletedTask;
    }
}
