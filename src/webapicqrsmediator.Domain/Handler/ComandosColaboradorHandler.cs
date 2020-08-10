using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Agents;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Entities;

namespace webapicqrsmediator.Domain.Handler
{
    public class ComandosColaboradorHandler : IRequestHandler<ColaboradorRequest, ColaboradorResponse>
    {
        private readonly IColaboradorAgent _colaboradorAgent;

        public ComandosColaboradorHandler(IColaboradorAgent colaboradorAgent)
        {
            _colaboradorAgent = colaboradorAgent;
        }

        public async Task<ColaboradorResponse> Handle(ColaboradorRequest request, CancellationToken cancellationToken)
        {
            var colaborador = new Colaborador(
                nome: request.Nome,
                salario: request.Salario,
                idade: request.Idade
            );

            var response = await _colaboradorAgent.AdicionarColaborador(colaborador);

            return new ColaboradorResponse
            {
                Id = Guid.NewGuid().ToString(),
                Status = response.Status,
                Nome = response.Dados?.Nome,
            };
        }
    }
}