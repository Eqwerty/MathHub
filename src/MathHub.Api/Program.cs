using MathHub.Api.Extensions;
using MathHub.Api.Options;
using MathHub.Api.Repositories;
using MathHub.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Sources.Clear();

builder.Configuration
    .AddEnvironmentVariables("MATHHUB_")
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

builder.Services.AddTransient<IMathService, MathService>();
builder.Services.AddTransient<IGuidsService, GuidsService>();
builder.Services.AddSingleton<IGuidsRepository, GuidsRepository>();

builder.Services.AddOptions<DatabaseOptions>()
    .Bind(builder.Configuration.GetSection("database"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
