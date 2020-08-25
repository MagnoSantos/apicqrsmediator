using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using webapicqrsmediator.Shared;

namespace webapicqrsmediator.Api.Util
{
    public class ApiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiMiddleware> _logger;

        public ApiMiddleware(
            RequestDelegate next,
            ILogger<ApiMiddleware> logger
        )
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                _logger.LogInformation($"Requisição solicitada na API", httpContext.Request.Body.ObterConteudo());

                await _next(httpContext);

                _logger.LogInformation($"Requisição completa pela API", httpContext.Response.Body.ObterConteudo());
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