using Happy.Weddings.Gateway.Core.Config.Blog;
using Happy.Weddings.Gateway.Core.Config.Identity;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding health checks
    /// </summary>
    public static class HealthCheck
    {
        /// <summary>
        /// Adds the health checks.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddHealthChecks(this IServiceCollection services,
                                                         IConfiguration configuration)
        {
            var servicesConfig = configuration.GetSection("ServicesConfig").Get<ServicesConfig>();

            services.AddHealthChecks()
               .AddUrlGroup(new Uri(servicesConfig.Identity + IdentityServiceOperation.GetHealth()), name: "Identity Service")
               .AddUrlGroup(new Uri(servicesConfig.Blog + BlogServiceOperation.GetHealth()), name: "Blogs Service");

            return services;
        }
    }
}
