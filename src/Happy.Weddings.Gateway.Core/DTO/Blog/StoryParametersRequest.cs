using System;

namespace Happy.Weddings.Gateway.Core.DTO.Blog
{
    public class StoryParametersRequest : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoryParametersRequest"/> class.
        /// </summary>
        public StoryParametersRequest()
        {
            OrderBy = "Title";
        }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }
    }
}
