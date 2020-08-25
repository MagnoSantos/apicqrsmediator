using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Infrastructure.DataAgents;

namespace webapicqrsmediator.Domain.Handler
{
    public class ComandosColaboradorHandler : IRequestHandler<AdicionarColaboradorDataRequest, AdicionarColaboradorDataResponse>
    {
        private readonly IDummyAgent _colaboradorAgent;

        public ComandosColaboradorHandler(IDummyAgent colaboradorAgent)
        {
            _colaboradorAgent = colaboradorAgent;
        }

        public async Task<AdicionarColaboradorDataResponse> Handle(AdicionarColaboradorDataRequest request, CancellationToken cancellationToken)
        {
            var response = await _colaboradorAgent.AdicionarColaborador(
                nome: request.Nome,
                salario: request.Salario,
                idade: request.Idade
            );

            return new AdicionarColaboradorDataResponse
            {
                Id = Guid.NewGuid().ToString(),
                Status = response.Status,
                Nome = response.Dados?.Nome,
            };
        }
    }
}