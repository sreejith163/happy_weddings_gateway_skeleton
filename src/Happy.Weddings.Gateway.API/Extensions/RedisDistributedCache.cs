using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding redis distributed cache exchange
    /// </summary>
    public static class RedisDistributedCache
    {
        /// <summary>
        /// Adds the redis cache exchange.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddRedisCacheExchange(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["RedisCache:ConnectionString"];
            });

            return services;
        }
    }
}
