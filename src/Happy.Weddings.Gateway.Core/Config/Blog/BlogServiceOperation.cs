using System;

namespace Happy.Weddings.Gateway.Core.Config.Blog
{
    public class BlogServiceOperation
    {
        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/blogs";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "BlogService";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"{baseUrl}/hc";

        /// <summary>
        /// Gets the stories.
        /// </summary>
        /// <returns></returns>
        public static string GetStories() => $"{baseUrl}/stories";

        /// <summary>
        /// Gets the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        public static string GetStory(Guid storyId) => $"{baseUrl}/stories/{storyId}";

        /// <summary>
        /// Creates the story.
        /// </summary>
        /// <returns></returns>
        public static string CreateStory() => $"{baseUrl}/stories";

        /// <summary>
        /// Updates the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        public static string UpdateStory(Guid storyId) => $"{baseUrl}/stories/{storyId}";

        /// <summary>
        /// Deletes the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        public static string DeleteStory(Guid storyId) => $"{baseUrl}/stories/{storyId}";
    }
}
