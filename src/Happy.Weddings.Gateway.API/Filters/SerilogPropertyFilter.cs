using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.API.Filters
{
    /// <summary>
    /// Serilog filter for adding dynamic properties
    /// </summary>
    public class SerilogPropertyFilter
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogPropertyFilter" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public SerilogPropertyFilter(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task Invoke(HttpContext context)
        {
            using (LogContext.PushProperty("Address", context.Connection.RemoteIpAddress.ToString() ?? "unknown"))
            {
                await _next.Invoke(context);
            }
        }
    }
}
