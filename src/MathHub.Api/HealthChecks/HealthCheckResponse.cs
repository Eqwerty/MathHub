namespace MathHub.Api.HealthChecks;

internal class HealthCheckResponse
{
    public string Status { get; init; }

    public IEnumerable<HealthCheck> HealthChecks { get; init; }

    public TimeSpan Duration { get; init; }
}
