namespace Happy.Weddings.Gateway.Core.DTO.Blog
{
    public class QueryStringParameters
    {
        /// <summary>
        /// The maximum page size
        /// </summary>
        const int maxPageSize = 10;

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The page size
        /// </summary>
        private int pageSize = 10;

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        public string Fields { get; set; }
    }
}
