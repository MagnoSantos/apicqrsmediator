using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace webapicqrsmediator.Api.Extensions
{
    public static class FluentValidationConfig
    {
        /// <summary>
        /// Configuração do Fluent Validation para validação do corpo da requisição
        /// </summary>
        /// <param name="services">Parâmetro de services para configuração</param>
        public static void ConfigurarFluentValidation(this IServiceCollection services)
        {
            services.AddMvc()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}