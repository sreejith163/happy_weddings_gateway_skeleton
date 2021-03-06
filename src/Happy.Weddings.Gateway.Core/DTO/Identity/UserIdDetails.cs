﻿using System;

namespace Happy.Weddings.Gateway.Core.DTO.Identity
{
    public class UserIdDetails
    {
        /// <summary>
        /// Gets or sets the story identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdDetails" /> class.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        public UserIdDetails(int userId)
        {
            UserId = userId;
        }
    }
}
