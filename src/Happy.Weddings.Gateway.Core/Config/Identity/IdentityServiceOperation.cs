using System;

namespace Happy.Weddings.Gateway.Core.Config.Identity
{
    public class IdentityServiceOperation
    {
        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/identity";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "IdentityService";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"{baseUrl}/hc";

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public static string GetUsers() => $"{baseUrl}/users";

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static string GetUser(Guid userId) => $"{baseUrl}/users/{userId}";

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static string CreateUser() => $"{baseUrl}/users";

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static string UpdateUser(Guid userId) => $"{baseUrl}/users/{userId}";

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static string DeleteUser(Guid userId) => $"{baseUrl}/users/{userId}";
    }
}
