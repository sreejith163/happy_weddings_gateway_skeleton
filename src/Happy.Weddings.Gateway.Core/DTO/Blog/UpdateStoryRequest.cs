namespace Happy.Weddings.Gateway.Core.DTO.Blog
{
    public class UpdateStoryRequest
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
