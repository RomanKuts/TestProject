using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;
using TestProject.Services.DataAccess;

namespace TestProject.Services.Configurations;

public static class RefitConfiguration
{
    public static IServiceCollection ConfigureRefit(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new RefitSettings(new SystemTextJsonContentSerializer(new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        }));

        var baseAddress = new Uri("https://localhost:7198");

        services.AddRefitClient<IWorkOrderApi>(settings)
            .ConfigureHttpClient(c => c.BaseAddress = baseAddress);

        services.AddRefitClient<IVisitApi>(settings)
            .ConfigureHttpClient(c => c.BaseAddress = baseAddress);

        services.AddRefitClient<IPartApi>(settings)
            .ConfigureHttpClient(c => c.BaseAddress = baseAddress);

        return services;
    }
}