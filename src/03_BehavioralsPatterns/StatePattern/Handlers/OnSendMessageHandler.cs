using MediatR;
using StatePattern.Events;
using StatePattern.Models.FiniteStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatePattern.Handlers;

public class OnSendMessageHandler : INotificationHandler<OnEvent>
{
    private readonly IMessageService messageService;

    public OnSendMessageHandler(IMessageService messageService)
    {
        this.messageService = messageService;
    }

    public Task Handle(OnEvent notification, CancellationToken cancellationToken)
    {
        messageService.Send("załącz przekaźnik");

        return Task.CompletedTask;
    }
}
