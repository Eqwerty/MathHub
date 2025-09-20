namespace MathHub.Api.HealthChecks;

internal class HealthCheckResponse
{
    public required string Status { get; init; }

    public required IEnumerable<HealthCheck> HealthChecks { get; init; }

    public TimeSpan Duration { get; init; }
}
