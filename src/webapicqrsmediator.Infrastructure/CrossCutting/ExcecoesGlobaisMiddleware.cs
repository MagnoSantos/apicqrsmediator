using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace webapicqrsmediator.Infrastructure.CrossCutting
{
    public class ExcecoesGlobaisMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcecoesGlobaisMiddleware> _logger;

        public ExcecoesGlobaisMiddleware(
            RequestDelegate next,
            ILogger<ExcecoesGlobaisMiddleware> logger
        )
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Excecao", ex);

                var codigo = HttpStatusCode.InternalServerError;

                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                httpContext.Response.StatusCode = (int)codigo;
                await httpContext.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        new { erro = ex.Message },
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        })
                );
            }
        }
    }
}