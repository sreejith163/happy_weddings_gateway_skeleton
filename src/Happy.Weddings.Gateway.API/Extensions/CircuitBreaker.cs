using Happy.Weddings.Gateway.Core.Config.Blog;
using Happy.Weddings.Gateway.Core.Config.Identity;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding circuit breakers
    /// </summary>
    public static class CircuitBreaker
    {
        /// <summary>
        /// Adds the circuit breakers.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddCircuitBreakers(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            var servicesConfig = configuration.GetSection("ServicesConfig").Get<ServicesConfig>();

            services.AddHttpClient(IdentityServiceOperation.serviceName, c => { c.BaseAddress = new Uri(servicesConfig.Identity); })
                     .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(10, TimeSpan.FromMinutes(2)));
            services.AddHttpClient(BlogServiceOperation.serviceName, c => { c.BaseAddress = new Uri(servicesConfig.Blog); })
                    .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(10, TimeSpan.FromMinutes(2)));

            return services;
        }
    }
}
