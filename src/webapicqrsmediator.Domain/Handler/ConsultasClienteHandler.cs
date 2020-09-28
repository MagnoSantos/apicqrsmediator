using MediatR;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Interfaces.Converters;
using webapicqrsmediator.Domain.Interfaces.Repositories;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Domain.Queries.Response;

namespace webapicqrsmediator.Domain.Handler
{
    public class ConsultasClienteHandler :
        IRequestHandler<ObterClientePorIdRequest, ObterClientePorIdResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IConversor<Cliente, ObterClientePorIdResponse> _conversor;

        public ConsultasClienteHandler(IClienteRepository clienteRepository,
                                       IConversor<Cliente, ObterClientePorIdResponse> conversor)
        {
            _clienteRepository = clienteRepository;
            _conversor = conversor;
        }

        public async Task<ObterClientePorIdResponse> Handle(ObterClientePorIdRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorId(request.Id);

            if (cliente == null) return null;

            return _conversor.Convert(cliente);
        }
    }
}