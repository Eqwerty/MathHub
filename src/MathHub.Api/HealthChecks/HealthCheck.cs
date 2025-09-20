namespace MathHub.Api.HealthChecks;

internal class HealthCheck
{
    public string Status { get; init; }

    public string Component { get; init; }

    public string? Description { get; init; }
}
