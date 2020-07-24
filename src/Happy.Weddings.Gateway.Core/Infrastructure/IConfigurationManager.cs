namespace Happy.Weddings.Gateway.Core.Infrastructure
{
    /// <summary>
    /// Interface for managing configuration related information
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Get Application Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Get Applciation Version
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Get Applciation URL
        /// </summary>
        string ApplicationURL { get; }

        /// <summary>
        /// Get Route to Access Swagger
        /// </summary>
        string SwaggerRoutePrefix { get; }
    }
}