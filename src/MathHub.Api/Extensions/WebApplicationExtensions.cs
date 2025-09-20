using MathHub.Api.Endpoints;

namespace MathHub.Api.Extensions;

internal static class WebApplicationExtensions
{
    public static void UseEndpoints(this WebApplication app)
    {
        MathEndpoints.DefineEndpoints(app);
        GuidsEndpoints.DefineEndpoints(app);
        ConfigurationEndpoints.DefineEndpoints(app);
    }
}
