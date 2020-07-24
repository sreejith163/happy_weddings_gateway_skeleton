using Happy.Weddings.Gateway.Core.Config.Identity;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.API.AuthorizationRequirements
{
    /// <summary>
    /// Filter that checks if the User specified by the UserName exists in Assist
    /// </summary>
    public class UserIdExistsRequirementHandler : AuthorizationHandler<UserIdRequirement>, IAuthorizationRequirement
    {
        /// <summary>
        /// The HTTP client factory
        /// </summary>
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// The services configuration
        /// </summary>
        private readonly ServicesConfig servicesConfig;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<UserIdExistsRequirementHandler> logger;

        /// <summary>
        /// The authorization configuration
        /// </summary>
        private readonly AuthorizationConfig authorizationConfig;

        /// <summary>
        /// Initializes the insatnce of the class
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">Represents the logger</param>
        /// <param name="authorizationConfig">The authorization configuration.</param>
        public UserIdExistsRequirementHandler(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger<UserIdExistsRequirementHandler> logger,
            AuthorizationConfig authorizationConfig)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
            this.authorizationConfig = authorizationConfig;
        }

        /// <summary>
        /// Check if  requirement has been handled
        /// </summary>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIdRequirement requirement)
        {
            try
            {
                var claimsIdentity = context.User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    var userIdClaim = claimsIdentity.FindFirst(c => c.Type == requirement.UserIdClaim && c.Issuer == authorizationConfig.Issuer);

                    if (!string.IsNullOrEmpty(userIdClaim?.Value))
                    {
                        var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);
                        var response = client.GetAsync(servicesConfig.Blog + IdentityServiceOperation.GetUser(Guid.Parse(userIdClaim?.Value))).Result;
                        var result = JsonConvert.DeserializeObject<APIResponse>(response.Content.ReadAsStringAsync().Result);

                        if (result.Code == HttpStatusCode.OK)
                        {
                            context.Succeed(requirement);
                        }
                    }
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserIdExistsRequirement::HandleRequirementAsync");
                return Task.CompletedTask;
            }
        }
    }
}
