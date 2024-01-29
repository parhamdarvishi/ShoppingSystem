using Prometheus;

namespace ShoppingSystem.Notification.Api.Prometheus;

public sealed class PrometheusHealthCheckPublisherOptions
{
    private const string DefaultName = "AspNetCore_HealthCheck_Status";
    private const string DefaultHelp = "ASP.NET Core Health Check Status (0 == Unhealthy, 0.5 == Degraded, 1 == Healthy)";

    public Gauge Gauge { get; set; } = Metrics.CreateGauge(DefaultName, DefaultHelp, labelNames: new[] { "name" });
}
