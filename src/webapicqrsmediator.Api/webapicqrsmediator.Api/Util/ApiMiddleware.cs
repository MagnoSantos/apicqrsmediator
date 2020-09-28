using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
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
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Excecao", ex);

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
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