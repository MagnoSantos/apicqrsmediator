using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using webapicqrsmediator.Domain;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Converters;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Interfaces.Converters;
using webapicqrsmediator.Domain.Interfaces.Repositories;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Domain.Queries.Response;
using webapicqrsmediator.Infrastructure.CrossCutting.Caching.Options;
using webapicqrsmediator.Infrastructure.Data.Context;
using webapicqrsmediator.Infrastructure.Data.Repositories;
using webapicqrsmediator.Infrastructure.DataAgents;
using webapicqrsmediator.Infrastructure.DataAgents.Options;

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
            services.Configure<CacheOptions>(options =>
            {
                options.TempoRetencaoCacheEmDias = configuration.GetValue<uint>("AppConfiguration:TempoRetencaoCacheEmDias");
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
            services.ConfigurarConverters();
        }

        private static void ConfigurarMediator(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(AdicionarClienteDataRequest).GetTypeInfo().Assembly)
                .AddMediatR(typeof(ObterClientePorIdRequest).GetTypeInfo().Assembly)
                .AddMediatR(typeof(AdicionarColaboradorDataRequest).GetTypeInfo().Assembly)
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
                .AddTransient<IValidator<AdicionarClienteDataRequest>, AdicionarClienteValidator>();
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

        private static void ConfigurarConverters(this IServiceCollection services)
        {
            services
                .AddTransient<IConversor<AdicionarClienteDataRequest, Cliente>, ClienteConverter>()
                .AddTransient<IConversor<AdicionarClienteDataRequest, AdicionarClienteDataResponse>, ClienteAdicionarResponseConverter>()
                .AddTransient<IConversor<Cliente, ObterClientePorIdResponse>, ClienteObterPorIdResponseConverter>();
        }
    }
}