using MediatR;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Interfaces.Repositories;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Domain.Queries.Response;

namespace webapicqrsmediator.Domain.Handler
{
    public class ConsultasClienteHandler :
        IRequestHandler<ObterClientePorIdRequest, ObterClientePorIdResponse>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultasClienteHandler(
            IClienteRepository clienteRepository
        )
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ObterClientePorIdResponse> Handle(ObterClientePorIdRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorId(request.Id);

            if (cliente == null) return null;

            return new ObterClientePorIdResponse
            {
                Id = cliente.Id,
                Email = cliente.Email,
                Nome = cliente.Nome
            };
        }
    }
}