using System.Net.Http.Formatting;
using System.Web;

namespace TestWebService.Integration.Tests.ApiFacade
{
    public class WebApi
    {
        private static HttpClient _httpClient;

        public static void SetHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected static ApiResponse Send(HttpMethod httpMethod, string url)
        {
            return Send<object>(httpMethod, url, null);
        }

        protected static ApiResponse Send<T>(HttpMethod httpMethod, string url, T dto = null) where T : class
        {
            var request = new HttpRequestMessage(httpMethod, url)
            {
                Content = dto != null
                    ? new ObjectContent<T>(dto, new JsonMediaTypeFormatter(), "application/json")
                    : null
            };

            var httpResponse = _httpClient.SendAsync(request).ReadResponse(100000);
            return httpResponse;
        }

        protected static string ObjToQueryString(object query)
        {
            var parameters = from pi in query.GetType().GetProperties()
                             let propValue = pi.GetValue(query)
                             where propValue != null
                             let valueString = HttpUtility.UrlEncode(GetPropertyValue(propValue))
                             select $"{pi.Name}={valueString}";

            var queryString = string.Join("&", parameters);
            return queryString;
        }

        private static string GetPropertyValue(object propValue)
        {
            if (propValue is IEnumerable<int>)
            {
                return string.Join(",", (IEnumerable<int>)propValue);
            }
            if (propValue is IEnumerable<string>)
            {
                return string.Join(",", (IEnumerable<string>)propValue);
            }
            return propValue.ToString();
        }
    }
}
