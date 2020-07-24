using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding response compression
    /// </summary>
    public static class ResponseCompression
    {
        /// <summary>
        /// Adds the response compression.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection CreateResponseCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(GetMimeTypesForCompression());
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            return services;
        }

        /// <summary>
        /// Gets the MIME types for compression.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetMimeTypesForCompression()
        {
            return new[]
            {
                "application/json",
                "image/png",
                "image/jpeg",
                "image/gif",
                "image/tiff",
                "image/webp"
            };
        }
    }
}
