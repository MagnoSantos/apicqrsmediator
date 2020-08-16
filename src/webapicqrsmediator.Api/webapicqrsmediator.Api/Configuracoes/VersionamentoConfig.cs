using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace webapicqrsmediator.Api.Configuracoes
{
    public static class VersionamentoConfig
    {
        /// <summary>
        /// Configuração do versionamento da API
        /// </summary>
        /// <param name="services">Parâmetro de services para configuração</param>
        public static void ConfigurarVersionamento(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
        }
    }
}