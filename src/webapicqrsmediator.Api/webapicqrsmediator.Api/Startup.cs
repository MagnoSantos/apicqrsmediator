using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using webapicqrsmediator.Api.Configuracoes;
using webapicqrsmediator.Api.Extensions;
using webapicqrsmediator.Infrastructure.CrossCutting;

namespace webapicqrsmediator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configuração do Application Insights e Swagger através do nuget mrv-foundation (toolkit)
        /// Link de referência Arquitetura TI MRV (https://mrvengenharia.visualstudio.com/Arquitetura/_wiki/wikis/Arquitetura.wiki/1355/MRV-Toolkit)
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMemoryCache();

            services.ConfigurarComponentes();
            services.ConfigurarOptions(Configuration);
            services.ConfigurarFluentValidation();
            services.ConfigurarVersionamento();
            services.ConfigurarHealthCheck();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseMiddleware<ExcecoesGlobaisMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}