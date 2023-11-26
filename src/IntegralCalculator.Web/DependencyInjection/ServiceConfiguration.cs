using IntegralCalculator.Interfaces;
using IntegralCalculator.Services;
namespace IntegralCalculator.Web.DependencyInjection;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICalcularIntegralService, CalcularIntegralService>();
    }
}