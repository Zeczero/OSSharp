using Newtonsoft.Json;
using OSSharp.Core.ApiEndPoints;
using OSSharp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OSSharp.Core.Clients
{
    public class Base : IAsyncApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public Base(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<T> GetAsync<T>(Uri resource)
        {
            if (String.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("API Key is necessary.");
            }
            resource = AddParameter(resource, "apikey", _apiKey);

            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, resource)).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message); ;
            }
        }

        private Uri AddParameter(Uri url, string name, string value)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[name] = value;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        public Uri AddStringToQuery(string path) => AssembleUrl(path, new Dictionary<string, object>());

        public Uri AddStringToQuery(string path, Dictionary<string, object> parameter) => AssembleUrl(path, parameter);

        private Uri AssembleUrl(string path, Dictionary<string, object> parameter)
        {
            var urlParameters = new List<string>();
            foreach (var par in parameter)
            {
                urlParameters.Add(par.Value == null || string.IsNullOrWhiteSpace(par.Value.ToString())
                    ? null
                    : $"{par.Key}={par.Value.ToString()}");
            }

            var encodedParams = urlParameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(WebUtility.HtmlEncode)
                        .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}")
                            .ToArray();
            var url = encodedParams.Length > 0 ? $"{path}{string.Join(string.Empty, encodedParams)}" : path;

            return new Uri(BaseApiEndPointUrl.ApiEndPoint, url);
        }
    }
}
