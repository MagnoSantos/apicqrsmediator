using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace webapicqrsmediator.Api.HealthCheck
{
    public class DummyHealthCheck : IHealthCheck
    {


        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}