using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.DataAgents;

namespace webapicqrsmediator.Api.HealthCheck
{
    public class DummyHealthCheck : IHealthCheck
    {
        private readonly IColaboradorAgent _colaboradorAgent;

        public DummyHealthCheck(IColaboradorAgent colaboradorAgent)
        {
            _colaboradorAgent = colaboradorAgent;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default
        )
        {
            throw new System.NotImplementedException();
        }
    }
}