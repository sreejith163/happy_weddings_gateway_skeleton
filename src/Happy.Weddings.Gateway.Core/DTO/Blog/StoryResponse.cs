using System;

namespace Happy.Weddings.Gateway.Core.DTO.Blog
{
    public class StoryResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author { get; set; }

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
