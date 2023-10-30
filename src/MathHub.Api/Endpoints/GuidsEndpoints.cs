using MathHub.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MathHub.Api.Endpoints;

internal static class GuidsEndpoints
{
    public static void DefineEndpoints(WebApplication app)
    {
        var group = app.MapGroup("guids");

        group.MapGet("/", GetAll);
        group.MapPost("/", Add);
        group.MapDelete("/", Purge);
    }

    private static async Task<IResult> GetAll([FromServices] IGuidsService guidsService)
    {
        var guids = await guidsService.GetAsync();

        return Results.Ok(guids);
    }

    private static async Task<IResult> Add([FromServices] IGuidsService guidsService)
    {
        var newGuid = await guidsService.AddAsync();

        return Results.Ok(newGuid);
    }

    private static async Task<IResult> Purge([FromServices] IGuidsService guidsService)
    {
        await guidsService.PurgeAsync();

        return Results.NoContent();
    }
}
