using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.Identity
{
    /// <summary>
    /// Service interface for user related operations
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        Task<APIResponse> GetUsers();

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetUser(UserIdDetails details);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateUser(CreateUserRequest request);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateUser(UserIdDetails details, UpdateUserRequest request);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteUser(UserIdDetails details);
    }
}
