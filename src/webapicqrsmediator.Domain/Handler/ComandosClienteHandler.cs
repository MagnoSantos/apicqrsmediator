using MediatR;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Interfaces.Converters;
using webapicqrsmediator.Domain.Interfaces.Repositories;
using webapicqrsmediator.Domain.Notifications;

namespace webapicqrsmediator.Domain.Handler
{
    public class ComandosClienteHandler :
        IRequestHandler<AdicionarClienteDataRequest, AdicionarClienteDataResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;
        private readonly IConversor<AdicionarClienteDataRequest, Cliente> _conversorClienteModel;
        private readonly IConversor<AdicionarClienteDataRequest, AdicionarClienteDataResponse> _conversorClienteResponse;

        public ComandosClienteHandler(IClienteRepository clienteRepository,
                                      IMediator mediator,
                                      IConversor<AdicionarClienteDataRequest, Cliente> conversorModel,
                                      IConversor<AdicionarClienteDataRequest, AdicionarClienteDataResponse> conversorResponse)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
            _conversorClienteModel = conversorModel;
            _conversorClienteResponse = conversorResponse;
        }

        public async Task<AdicionarClienteDataResponse> Handle(AdicionarClienteDataRequest request, CancellationToken cancellationToken)
        {
            var cliente = _conversorClienteModel.Convert(request);

            await Task.WhenAll(
                _clienteRepository.Adicionar(cliente),
                _mediator.Publish(new AdicionarClienteDataNotification
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email
                })
            );

            return _conversorClienteResponse.Convert(request);
        }
    }
}