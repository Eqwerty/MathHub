using MathHub.Api.Endpoints;
using MathHub.Api.HealthChecks;
using MathHub.Api.Options;
using MathHub.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

builder.Services.AddHealthChecks().AddCheck<DatabaseHealthCheck>("database");
builder.Services.AddTransient<IMathService, MathService>();
builder.Services.AddOptions<DatabaseOptions>().Bind(builder.Configuration.GetSection("database"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseHealthChecks();

app.UseSwaggerUI();
app.UseSwagger();

app.UseMathEndpoints();

app.Run();
