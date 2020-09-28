using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Interfaces.Converters;
using webapicqrsmediator.Infrastructure.DataAgents;
using webapicqrsmediator.Infrastructure.DataAgents.Responses;

namespace webapicqrsmediator.Domain.Handler
{
    public class ComandosColaboradorHandler :
        IRequestHandler<AdicionarColaboradorDataRequest, AdicionarColaboradorDataResponse>
    {
        private readonly IColaboradorAgent _colaboradorAgent;
        private readonly IConversor<AdicionarColaboradorResponse, AdicionarColaboradorDataResponse> _conversor;

        public ComandosColaboradorHandler(IColaboradorAgent colaboradorAgent,
                                          IConversor<AdicionarColaboradorResponse, AdicionarColaboradorDataResponse> conversor)
        {
            _colaboradorAgent = colaboradorAgent;
            _conversor = conversor;
        }

        public async Task<AdicionarColaboradorDataResponse> Handle(AdicionarColaboradorDataRequest request, CancellationToken cancellationToken)
        {
            var response = await _colaboradorAgent.AdicionarColaborador(
                nome: request.Nome,
                salario: request.Salario,
                idade: request.Idade
            );

            return _conversor.Convert(response);
        }
    }
}