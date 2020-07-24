using Happy.Weddings.Gateway.Core.Domain.Identity;

namespace Happy.Weddings.Gateway.Core.Messaging.Sender.v1.Identity
{
    public interface IUsernameUpdateSender
    {
        /// <summary>
        /// Sends the name of the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void SendUserName(User user);
    }
}
