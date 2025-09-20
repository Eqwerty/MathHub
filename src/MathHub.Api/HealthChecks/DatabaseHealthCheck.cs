using MathHub.Api.Options;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace MathHub.Api.HealthChecks;

internal class DatabaseHealthCheck(IOptions<DatabaseOptions> options) : IHealthCheck
{
    private readonly IOptions<DatabaseOptions> _options = options;

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) =>
        Task.FromResult(_options.Value.ConnectionString is not null
            ? HealthCheckResult.Healthy()
            : HealthCheckResult.Unhealthy("Database connection string is not configured."));
}
