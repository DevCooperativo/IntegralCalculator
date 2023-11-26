using IntegralCalculator.Interfaces;
using IntegralCalculator.Services;
using IntegralCalculator.DTO;
namespace IntegralCalculator.Web.DependencyInjection;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICalcularIntegralService, CalcularIntegralService>();
        services.AddScoped<Dados>();
    }
}