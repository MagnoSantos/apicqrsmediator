using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Infrastructure.DataAgents;

namespace webapicqrsmediator.Domain.Handler
{
    public class ComandosColaboradorHandler : IRequestHandler<ColaboradorRequest, ColaboradorResponse>
    {
        private readonly IDummyAgent _colaboradorAgent;

        public ComandosColaboradorHandler(IDummyAgent colaboradorAgent)
        {
            _colaboradorAgent = colaboradorAgent;
        }

        public async Task<ColaboradorResponse> Handle(ColaboradorRequest request, CancellationToken cancellationToken)
        {
            var response = await _colaboradorAgent.AdicionarColaborador(
                nome: request.Nome,
                salario: request.Salario,
                idade: request.Idade
            );

            return new ColaboradorResponse
            {
                Id = Guid.NewGuid().ToString(),
                Status = response.Status,
                Nome = response.Dados?.Nome,
            };
        }
    }
}