using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;

namespace ShoppingSystem.Notification.Api.Prometheus;

public class PrometheusHealthCheckPublisher : IHealthCheckPublisher
{
    private readonly Gauge _checkStatus;

    public PrometheusHealthCheckPublisher(PrometheusHealthCheckPublisherOptions options)
    {
        _checkStatus = options?.Gauge ?? new PrometheusHealthCheckPublisherOptions().Gauge;
    }

    private static double HealthStatusToMetricValue(HealthStatus status)
    {
        return status switch
        {
            HealthStatus.Unhealthy => 0,
            HealthStatus.Degraded => 0.5,
            HealthStatus.Healthy => 1,
            _ => throw new NotSupportedException($"Unexpected HealthStatus value: {status}"),
        };
    }

    public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
    {
        foreach (var reportEntry in report.Entries)
            _checkStatus.WithLabels(reportEntry.Key).Set(HealthStatusToMetricValue(reportEntry.Value.Status));

        return Task.CompletedTask;
    }
}
