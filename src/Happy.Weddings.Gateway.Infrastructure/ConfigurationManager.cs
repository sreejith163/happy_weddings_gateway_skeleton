using Happy.Weddings.Gateway.Core.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Happy.Weddings.Gateway.Infrastructure
{
    public class ConfigurationManager : IConfigurationManager
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationManager"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ConfigurationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Get Application Title
        /// </summary>
        public string Title => configuration["Title"];

        /// <summary>
        /// Get Applciation Version
        /// </summary>
        public string Version => configuration["Version"];

        /// <summary>
        /// Get Applciation URL
        /// </summary>
        public string ApplicationURL => configuration["Environment:ApplicationURL"];

        /// <summary>
        /// Get Route to Access Swagger
        /// </summary>
        public string SwaggerRoutePrefix => configuration["Environment:SwaggerRoutePrefix"];
    }
}
