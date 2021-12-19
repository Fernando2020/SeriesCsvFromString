using Microsoft.Extensions.DependencyInjection;
using SeriesCsvFromString.Console.Services;
using SeriesCsvFromString.Service.Interfaces;

namespace SeriesCsvFromString.Service
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IReadCsvService, ReadCsvService>()
                .AddScoped<IWriteTxtService, WriteTxtService>();

            return services;
        }
    }
}
