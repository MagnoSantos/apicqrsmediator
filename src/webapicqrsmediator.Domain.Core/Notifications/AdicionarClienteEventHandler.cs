using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace webapicqrsmediator.Domain.Core.Notifications
{
    public class AdicionarClienteEventHandler :
        INotificationHandler<AdicionarClienteDataNotification>
    {
        public Task Handle(AdicionarClienteDataNotification notification, CancellationToken cancellationToken)
        {
            
        }
    }
}