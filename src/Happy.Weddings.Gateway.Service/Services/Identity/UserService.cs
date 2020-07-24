using Happy.Weddings.Gateway.Core.Config.Identity;
using Happy.Weddings.Gateway.Core.Domain.Identity;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Messaging.Sender.Identity;
using Happy.Weddings.Gateway.Core.Services.Identity;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.Identity
{
    /// <summary>
    /// Service implementation for user related operations
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// The username update sender
        /// </summary>
        private readonly IUsernameUpdateSender usernameUpdateSender;

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
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoryService" /> class.
        /// </summary>
        /// <param name="usernameUpdateSender">The username update sender.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public UserService(
            IUsernameUpdateSender usernameUpdateSender,
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.usernameUpdateSender = usernameUpdateSender;
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponse> GetUsers()
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Identity + IdentityServiceOperation.GetUsers());
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetUsers()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetUser(UserIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Identity + IdentityServiceOperation.GetUser(details.UserId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateUser(CreateUserRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Identity + IdentityServiceOperation.CreateUser(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateUser(UserIdDetails details, UpdateUserRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Identity + IdentityServiceOperation.UpdateUser(details.UserId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    var user = new User { Id = details.UserId, FirstName = request.FirstName, LastName = request.LastName };
                    usernameUpdateSender.SendUserName(user);
                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteUser(UserIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + IdentityServiceOperation.DeleteUser(details.UserId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
