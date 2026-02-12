using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace ShoeService.Host.Healthchecks
{
    public class BasicHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            // Тук може да добавиш логика за проверка на база, API, файлове и т.н.
            return Task.FromResult(HealthCheckResult.Healthy("Service is running"));
        }
    }
}
