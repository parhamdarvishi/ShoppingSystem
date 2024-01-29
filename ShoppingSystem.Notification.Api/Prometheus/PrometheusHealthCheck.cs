using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ShoppingSystem.Notification.Api.Prometheus;

public class PrometheusHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) => Task.FromResult(HealthCheckResult.Healthy());
}
