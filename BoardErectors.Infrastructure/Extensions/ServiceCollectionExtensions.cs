using BoardErectors.Application.Services;
using BoardErectors.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BoardErectors.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IEstateAgentAccountService, EstateAgentAccountService>();
            return services;
        }
    }
}
