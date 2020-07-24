using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding MVC related operations
    /// </summary>
    public static class MVCConfiguration
    {
        /// <summary>
        /// Adds the MVC confihuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddMVCConfiguration(this IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(new RequireHttpsAttribute());
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            });

            services.AddMvc().AddNewtonsoftJson();
            services.AddMvcCore().AddApiExplorer();

            services.AddCors(o => o.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            return services;
        }
    }
}
