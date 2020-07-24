using System;

namespace Happy.Weddings.Gateway.Core.DTO.Identity
{
    public class UpdateUserRequest
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public Guid UpdatedBy { get; set; }
    }
}
