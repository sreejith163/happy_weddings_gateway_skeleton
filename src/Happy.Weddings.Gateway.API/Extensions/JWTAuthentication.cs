using Happy.Weddings.Gateway.Core.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding JWT authentication
    /// </summary>
    public static class JWTAuthentication
    {
        /// <summary>
        /// Creates the response compression.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="HostingEnvironment">The hosting environment.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services,
                                                              IWebHostEnvironment HostingEnvironment,
                                                              IConfiguration configuration)
        {
            var authConfig = configuration.GetSection("AuthorizationConfig").Get<AuthorizationConfig>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = authConfig.Issuer,
                        ValidAudience = authConfig.Audience,
                        IssuerSigningKey = GetKey(authConfig.KeyFilePath, HostingEnvironment.WebRootPath)
                    };
                });

            return services;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <param name="keyFilePath">The key file path.</param>
        /// <param name="certificatePath">The certificate path.</param>
        /// <returns></returns>
        private static X509SecurityKey GetKey(string keyFilePath, string certificatePath)
        {
            X509Certificate2 certificate;
            certificate = new X509Certificate2(certificatePath + keyFilePath);
            return new X509SecurityKey(certificate);
        }
    }
}
