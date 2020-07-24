using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Messaging.Sender.v1.Identity;
using Happy.Weddings.Gateway.Core.Services.v1.Blog;
using Happy.Weddings.Gateway.Core.Services.v1.Identity;
using Happy.Weddings.Gateway.Infrastructure;
using Happy.Weddings.Gateway.Messaging.Sender.v1.Identity;
using Happy.Weddings.Gateway.Service.Services.v1.Blog;
using Happy.Weddings.Gateway.Service.Services.v1.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding object injection lifetime
    /// </summary>
    public static class ServicesInjection
    {
        /// <summary>
        /// Adds the services injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="HostingEnvironment">The hosting environment.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddServicesInjection(this IServiceCollection services,
                                                                           IWebHostEnvironment HostingEnvironment,
                                                                           IConfiguration configuration)
        {
            //Configure logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var rabbitMQConfig = configuration.GetSection("RabbitMqConfig").Get<RabbitMqConfig>();
            var servicesConfig = configuration.GetSection("ServicesConfig").Get<ServicesConfig>();
            var authorizationConfig = configuration.GetSection("AuthorizationConfig").Get<AuthorizationConfig>();

            services.AddSingleton(Log.Logger);
            services.AddSingleton(HostingEnvironment);
            services.AddSingleton(rabbitMQConfig);
            services.AddSingleton(servicesConfig);
            services.AddSingleton(authorizationConfig);

            services.AddTransient<IConfigurationManager, ConfigurationManager>();
            services.AddTransient<IStoryService, StoryService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUsernameUpdateSender, UsernameUpdateSender>();

            return services;
        }
    }
}
