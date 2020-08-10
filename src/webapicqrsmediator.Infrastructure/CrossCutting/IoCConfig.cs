using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Domain.Repositories;
using webapicqrsmediator.Infrastructure.Data.Context;
using webapicqrsmediator.Infrastructure.Data.Repositories;

namespace webapicqrsmediator.Infrastructure.CrossCutting
{
    public static class IoCConfig
    {
        /// <summary>
        /// Configurar os componentes da aplicação
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigurarComponentes(this IServiceCollection services)
        {
            services.ConfigurarMediator();
            services.ConfigurarRepositories();
            services.ConfigurarValidators();
            services.ConfiguraraData();
        }

        private static void ConfigurarMediator(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(AdicionarClienteRequest).GetTypeInfo().Assembly)
                .AddMediatR(typeof(ObterClientePorIdRequest).GetTypeInfo().Assembly)
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ApplicationLoggingBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingDecorateBehavior<,>));
        }

        private static void ConfigurarRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IClienteRepository, ClienteRepository>();
        }

        private static void ConfigurarValidators(this IServiceCollection services)
        {
            services
                .AddTransient<IValidator<AdicionarClienteRequest>, AdicionarClienteValidator>();
        }

        private static void ConfiguraraData(this IServiceCollection services)
        {
            services
                .AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Data Example"));

            services
                .AddScoped<DataContext>();
        }
    }
}