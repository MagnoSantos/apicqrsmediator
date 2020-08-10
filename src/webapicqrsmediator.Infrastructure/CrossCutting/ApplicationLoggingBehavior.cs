using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace webapicqrsmediator.Infrastructure.CrossCutting
{
    public class ApplicationLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ApplicationLoggingBehavior<TRequest, TResponse>> _logger;

        public ApplicationLoggingBehavior(ILogger<ApplicationLoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Middleware para tratativa de logs
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            _logger.LogInformation($"Requisição solicitada na API", request);

            var resposta = await next();

            _logger.LogInformation("Requisicao realizada com sucesso", resposta);

            return resposta;
        }
    }
}