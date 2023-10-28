using MathHub.Api.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMathService, MathService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/isEven/{number:int}", ([FromRoute] int number, [FromServices] IMathService mathService) => Results.Ok(mathService.IsEven(number)));

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
