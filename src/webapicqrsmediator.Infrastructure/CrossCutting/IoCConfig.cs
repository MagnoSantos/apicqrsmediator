using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using webapicqrsmediator.Domain;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Domain.Repositories;
using webapicqrsmediator.Infrastructure.Data.Agents;
using webapicqrsmediator.Infrastructure.Data.Agents.Options;
using webapicqrsmediator.Infrastructure.Data.Context;
using webapicqrsmediator.Infrastructure.Data.Repositories;

namespace webapicqrsmediator.Infrastructure.CrossCutting
{
    public static class IoCConfig
    {
        public static void ConfigurarOptions(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.Configure<DummyOptions>(options =>
            {
                options.UrlBase = configuration.GetValue<string>("AppConfiguration:UrlDummy");
            });
        }

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
            services.ConfigurarAgent();
        }

        private static void ConfigurarMediator(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(ClienteRequest).GetTypeInfo().Assembly)
                .AddMediatR(typeof(ObterClientePorIdRequest).GetTypeInfo().Assembly)
                .AddMediatR(typeof(ColaboradorRequest).GetTypeInfo().Assembly)
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
                .AddTransient<IValidator<ClienteRequest>, AdicionarClienteValidator>();
        }

        private static void ConfiguraraData(this IServiceCollection services)
        {
            services
                .AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Data Example"));

            services
                .AddScoped<DataContext>();
        }

        private static void ConfigurarAgent(this IServiceCollection services)
        {
            services
                .AddTransient<IColaboradorAgent, ColaboradorAgent>();
        }
    }
}