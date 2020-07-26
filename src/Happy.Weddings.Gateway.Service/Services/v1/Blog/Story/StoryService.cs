using Happy.Weddings.Gateway.Core.Config.Blog;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Blog;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Blog.Story;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.Blog.Story
{
    /// <summary>
    /// Service implementation for post related operations
    /// </summary>
    public class StoryService : IStoryService
    {
        /// <summary>
        /// The HTTP client factory
        /// </summary>
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// The distributed cache
        /// </summary>
        private readonly IDistributedCache distributedCache;

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
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public StoryService(
            IHttpClientFactory httpClientFactory,
            IDistributedCache distributedCache,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.distributedCache = distributedCache;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the stories.
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponse> GetStories()
        {
            try
            {
                string serializedStories;
                List<StoryResponse> stories;

                var encodedStories = await distributedCache.GetAsync(BlogServiceOperation.GetStoriesCacheName);

                if (encodedStories != null)
                {
                    serializedStories = Encoding.UTF8.GetString(encodedStories);
                    stories = JsonConvert.DeserializeObject<List<StoryResponse>>(serializedStories);
                }
                else
                {
                    var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);
                    var response = await client.GetAsync(servicesConfig.Blog + BlogServiceOperation.GetStories());
                    var result = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    stories = result.Value as List<StoryResponse>;

                    serializedStories = JsonConvert.SerializeObject(stories);
                    encodedStories = Encoding.UTF8.GetBytes(serializedStories);
                    var options = new DistributedCacheEntryOptions()
                                    .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                    .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                    await distributedCache.SetAsync(BlogServiceOperation.GetStoriesCacheName, encodedStories, options);
                }

                return new APIResponse(stories, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetStories()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the story.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetStory(StoryIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Blog + BlogServiceOperation.GetStory(details.StoryId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetStory()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the story.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateStory(CreateStoryRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Blog + BlogServiceOperation.CreateStory(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateStory()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the story.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateStory(StoryIdDetails details, UpdateStoryRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Blog + BlogServiceOperation.UpdateStory(details.StoryId), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateStory()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the story.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteStory(StoryIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Blog + BlogServiceOperation.DeleteStory(details.StoryId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteStory()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
