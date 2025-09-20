using MathHub.Api.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MathHub.Api.Endpoints;

internal static class ConfigurationEndpoints
{
    public static void DefineEndpoints(WebApplication app) => app.MapGet("/configuration", GetConnectionString);

    private static IResult GetConnectionString([FromServices] IOptions<DatabaseOptions> options) =>
        options.Value.ConnectionString is null
            ? Results.BadRequest("Connection string is not configured.")
            : Results.Ok(options.Value.ConnectionString);
}
