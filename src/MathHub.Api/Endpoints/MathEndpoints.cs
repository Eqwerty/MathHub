using MathHub.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MathHub.Api.Endpoints;

internal static class MathEndpoints
{
    public static void UseMathEndpoints(this WebApplication app) => app.MapGet("/isEven/{number:int}", IsEven);

    private static IResult IsEven([FromRoute] int number, [FromServices] IMathService mathService)
    {
        var isEven = mathService.IsEven(number);

        return Results.Ok(isEven);
    }
}
