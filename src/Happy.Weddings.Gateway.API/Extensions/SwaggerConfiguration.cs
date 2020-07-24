using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding swagger documentation
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Creates the response compression.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    configuration["Version"],
                    new OpenApiInfo { Title = configuration["Title"], Version = configuration["Version"] });
                c.IncludeXmlComments(@"App_Data\api-comments.xml");
                c.AddSecurityDefinition("Bearer", GetSwaggerSecurityScheme());
                c.OperationFilter<SecurityRequirementsOperationFilter>("Bearer");
            });

            return services;
        }

        /// <summary>
        /// Gets the swagger security scheme.
        /// </summary>
        /// <returns></returns>
        private static OpenApiSecurityScheme GetSwaggerSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header. Example: " + "{token}",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = "bearer",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT"
            };
        }
    }
}
