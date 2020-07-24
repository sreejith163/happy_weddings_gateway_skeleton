using System;

namespace Happy.Weddings.Gateway.Core.DTO.Identity
{
    public class UserResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

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
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public Guid UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        public DateTime UpdatedOn { get; set; }
    }
}
