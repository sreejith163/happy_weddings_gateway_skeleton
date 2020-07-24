using Happy.Weddings.Gateway.API.Extensions;
using Happy.Weddings.Gateway.API.Filters;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Happy.Weddings.Gateway.API
{
    /// <summary>
    /// Base method for intilaizing the services
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the hosting environment.
        /// </summary>
        public IWebHostEnvironment HostingEnvironment { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="hostingEnvironment">The hosting environment.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddJWTAuthentication(HostingEnvironment, Configuration)
                .AddMVCConfiguration()
                .CreateResponseCompression()
                .AddFluentAbstractValidators()
                .AddSwaggerConfiguration(Configuration)
                .AddHealthChecks(Configuration)
                .AddCircuitBreakers(Configuration)
                .AddRedisCacheExchange(Configuration)
                .AddServicesInjection(HostingEnvironment, Configuration)
                .ForwardHeaders()
                .AddControllers();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "DENY"); 
                context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
                await next();
            });
            app.UseForwardedHeaders();

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseStaticFiles();
            app.UseCors("AllowAllOrigins");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = Configuration["Environment:SwaggerRoutePrefix"];
                c.DocumentTitle = Configuration["Title"] + " " + Configuration["Version"];
                c.SwaggerEndpoint(Configuration["Environment:ApplicationURL"] + "/swagger/" + Configuration["Version"] + "/swagger.json", Configuration["Title"] + " " + Configuration["Version"]);
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<SerilogPropertyFilter>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }        
    }
}
