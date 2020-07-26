using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.Services.v1.Identity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Identity
{
    /// <summary>
    /// Identity users operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// The story service
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UsersController(
            IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await userService.GetUsers();
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [Route("{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int userId)
        {
            var result = await userService.GetUser(new UserIdDetails(userId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await userService.CreateUser(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{userId}")]
        [HttpPut]
        [Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserRequest request)
        {
            var result = await userService.UpdateUser(new UserIdDetails(userId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [Route("{userId}")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await userService.DeleteUser(new UserIdDetails(userId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
