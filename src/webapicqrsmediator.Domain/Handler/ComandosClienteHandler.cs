using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Entities;
using webapicqrsmediator.Domain.Repositories;

namespace webapicqrsmediator.Domain.Handler
{
    public class ComandosClienteHandler : IRequestHandler<ClienteRequest, ClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;

        public ComandosClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteResponse> Handle(ClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Nome, request.Email, DateTime.UtcNow);

            await _clienteRepository.Adicionar(cliente);

            return new ClienteResponse
            {
                Id = cliente.Id, 
                Nome = cliente.Nome, 
                Email = cliente.Email, 
                DataCriacao = cliente.DataCriacao
            };
        }
    }
}