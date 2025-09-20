namespace MathHub.Api.HealthChecks;

internal class HealthCheck
{
    public required string Status { get; init; }

    public required string Component { get; init; }

    public string? Description { get; init; }
}
