using System.Linq;
using System.Web;

namespace Happy.Weddings.Gateway.Service.Helpers
{
    public class QueryStringHelper
    {
        /// <summary>
        /// Converts to query string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static string ConvertToQueryString<T>(T entity) where T : class
        {
            var props = typeof(T).GetProperties();

            return $"?{string.Join('&', props.Where(r => r.GetValue(entity) != null).Select(r => $"{HttpUtility.UrlEncode(r.Name)}={HttpUtility.UrlEncode(r.GetValue(entity).ToString())}"))}";
        }
    }
}
