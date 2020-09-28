using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace webapicqrsmediator.Domain.Notifications
{
    public class AdicionarClienteEventHandler :
        INotificationHandler<AdicionarClienteDataNotification>
    {
        public Task Handle(AdicionarClienteDataNotification notification, CancellationToken cancellationToken)
        {
            //Enviar por exemplo um email de notificação (usar fila)
            return Task.CompletedTask;
        }
    }
}