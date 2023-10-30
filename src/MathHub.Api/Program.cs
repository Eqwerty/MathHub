using MathHub.Api.Extensions;
using MathHub.Api.Repositories;
using MathHub.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMathService, MathService>();
builder.Services.AddTransient<IGuidsService, GuidsService>();
builder.Services.AddSingleton<IGuidsRepository, GuidsRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
