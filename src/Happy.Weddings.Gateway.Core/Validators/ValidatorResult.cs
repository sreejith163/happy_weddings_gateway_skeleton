using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.Validators
{
    /// <summary>
    /// Contains the details of the validation
    /// </summary>
    public class ValidatorResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorResult"/> class.
        /// </summary>
        public ValidatorResult()
        {
            Errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets if the instance is valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        public Dictionary<string, string> Errors { get; }
    }
}