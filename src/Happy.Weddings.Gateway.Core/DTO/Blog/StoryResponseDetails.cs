using Happy.Weddings.Gateway.Core.Domain.Blog;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Blog
{
    public class StoryResponseDetails : StoryResponse
    {
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Comments> Comments { get; set; }
    }
}
