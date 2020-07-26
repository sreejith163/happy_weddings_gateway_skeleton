using System;

namespace Happy.Weddings.Gateway.Core.Domain.Blog
{
    public class Comments
    {
        /// <summary>
        /// Gets or sets the comment identifier.
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// Gets or sets the story identifier.
        /// </summary>
        public int StoryId { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
