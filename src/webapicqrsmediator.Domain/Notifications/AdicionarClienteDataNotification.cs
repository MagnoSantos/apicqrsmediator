using MediatR;

namespace webapicqrsmediator.Domain.Notifications
{
    public class AdicionarClienteDataNotification : INotification
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}