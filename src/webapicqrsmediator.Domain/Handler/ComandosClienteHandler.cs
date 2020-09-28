using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Interfaces.Repositories;
using webapicqrsmediator.Domain.Notifications;

namespace webapicqrsmediator.Domain.Handler
{
    public class ComandosClienteHandler :
        IRequestHandler<AdicionarClienteDataRequest, AdicionarClienteDataResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ComandosClienteHandler(IClienteRepository clienteRepository,
                                      IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        public async Task<AdicionarClienteDataResponse> Handle(AdicionarClienteDataRequest request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Nome, request.Email, DateTime.UtcNow);

            await Task.WhenAll(
                _clienteRepository.Adicionar(cliente),
                _mediator.Publish(new AdicionarClienteDataNotification
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email
                })
            );

            return new AdicionarClienteDataResponse
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                DataCriacao = cliente.DataCriacao
            };
        }
    }
}