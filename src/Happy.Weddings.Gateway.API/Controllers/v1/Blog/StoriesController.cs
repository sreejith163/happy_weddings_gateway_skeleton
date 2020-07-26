using System.Threading.Tasks;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Blog;
using Happy.Weddings.Gateway.Core.Services.v1.Blog.Story;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Blog
{
    /// <summary>
    /// Blog stories operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/blogs/stories")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        /// <summary>
        /// The story service
        /// </summary>
        private readonly IStoryService storyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesController"/> class.
        /// </summary>
        /// <param name="storyService">The story service.</param>
        public StoriesController(
            IStoryService storyService)
        {
            this.storyService = storyService;
        }

        /// <summary>
        /// Gets the stories.
        /// </summary>
        /// <param name="storyParametersRequest">The story parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetStories([FromQuery] StoryParametersRequest storyParametersRequest)
        {
            var result = await storyService.GetStories(storyParametersRequest);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        [Route("{storyId}")]
        [HttpGet]
        public async Task<IActionResult> GetStory(int storyId)
        {
            var result = await storyService.GetStory(new StoryIdDetails(storyId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the story.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateStory([FromBody] CreateStoryRequest request)
        {
            var result = await storyService.CreateStory(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{storyId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateStory(int storyId, [FromBody] UpdateStoryRequest request)
        {
            var result = await storyService.UpdateStory(new StoryIdDetails(storyId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        [Route("{storyId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStory(int storyId)
        {
            var result = await storyService.DeleteStory(new StoryIdDetails(storyId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
