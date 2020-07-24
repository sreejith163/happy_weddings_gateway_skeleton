using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding reverse proxy
    /// </summary>
    public static class ProxyHeaders
    {
        /// <summary>
        /// Forwards the headers.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ForwardHeaders(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            return services;
        }
    }
}
