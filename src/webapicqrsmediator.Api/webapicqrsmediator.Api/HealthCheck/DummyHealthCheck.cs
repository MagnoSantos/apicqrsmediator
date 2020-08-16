using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.DataAgents;

namespace webapicqrsmediator.Api.HealthCheck
{
    public class DummyHealthCheck : IHealthCheck
    {
        private readonly IDummyAgent _dummyAgent;

        public DummyHealthCheck(IDummyAgent dummyAgent)
        {
            _dummyAgent = dummyAgent;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default
        )
        {
            try
            {
                var colaboradores = await _dummyAgent.BuscarTodosColaboradores();
                
                if (colaboradores == null)
                {
                    return HealthCheckResult.Unhealthy(
                        description: "Integracao com a API do Dummy nao retornou nenhum colaborador"
                    );
                }

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(
                    description: "Falha ao comunicar com a API do Dummy",
                    exception: ex                    
                );
            }
        }
    }
}