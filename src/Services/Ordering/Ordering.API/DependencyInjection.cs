

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
         
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        //app.MapCarter();

        //app.UseExceptionHandler(options => { });
        //app.UseHealthChecks("/health",
        //    new HealthCheckOptions
        //    {
        //        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        //    });

        return app;
    }
}
