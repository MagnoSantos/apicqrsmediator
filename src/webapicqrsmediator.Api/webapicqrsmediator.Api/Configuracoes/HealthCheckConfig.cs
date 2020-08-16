using Microsoft.Extensions.DependencyInjection;
using webapicqrsmediator.Api.HealthCheck;

namespace webapicqrsmediator.Api.Configuracoes
{
    public static class HealthCheckConfig
    {
        /// <summary>
        /// As verificações de integridade da aplicação com health check são facilitadas a partir do .NET CORE 2.2
        /// Link de referência: https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-3.1
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigurarHealthCheck(this IServiceCollection services)
        {
            services
                .AddHealthChecks()
                //.AddAzureTableStorage("connection string", "descricao")
                //.AddAzureKeyVault("Url KeyVault", "descricao")
                .AddCheck<DummyHealthCheck>("Dummy API Integração");
        }
    }
}