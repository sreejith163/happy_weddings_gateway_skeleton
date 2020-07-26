using System;

namespace Happy.Weddings.Gateway.Core.DTO.Blog
{
    public class StoryIdDetails
    {
        /// <summary>
        /// Gets or sets the story identifier.
        /// </summary>
        public int StoryId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoryIdDetails"/> class.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        public StoryIdDetails(int storyId)
        {
            StoryId = storyId;
        }
    }
}
