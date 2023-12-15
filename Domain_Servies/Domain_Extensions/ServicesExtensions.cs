using Domain_Servies.Domain_IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Domain_Servies.Domain_Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection LoadServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IPersonServices, Domain_Services.PesonServices>();
            return services;
        }
    }
}
