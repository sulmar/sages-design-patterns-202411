using MediatR;
using StatePattern.Events;
using StatePattern.Models.FiniteStateMachine;
using System.Threading;
using System.Threading.Tasks;

namespace StatePattern.Handlers;

public class OffRelayHandler : INotificationHandler<OffEvent>
{
    private readonly IRelayService relayService;

    public OffRelayHandler(IRelayService relayService)
    {
        this.relayService = relayService;
    }

    public Task Handle(OffEvent notification, CancellationToken cancellationToken)
    {
        relayService.Disable(1);

        return Task.CompletedTask;
    }
}
