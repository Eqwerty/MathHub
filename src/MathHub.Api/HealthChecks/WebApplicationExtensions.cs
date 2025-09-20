using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MathHub.Api.HealthChecks;

internal static class WebApplicationExtensions
{
    public static void UseHealthChecks(this WebApplication app) =>
        app.UseHealthChecks("/health",
            new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    var response = JsonSerializer.Serialize(report.ToHealthCheckResponse());
                    await context.Response.WriteAsync(response);
                }
            });

    private static HealthCheckResponse ToHealthCheckResponse(this HealthReport report) =>
        new()
        {
            Status = report.Status.ToString(),
            HealthChecks = report.Entries.Select(entry =>
                new HealthCheck
                {
                    Status = entry.Value.Status.ToString(),
                    Component = entry.Key,
                    Description = entry.Value.Description
                }
            ),
            Duration = report.TotalDuration
        };
}
