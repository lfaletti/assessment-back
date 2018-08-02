using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.Services.Providers
{
    /// <summary>
    ///  A generic Base class to get REST external resources
    ///  assumptions: JSON deserialization
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRestApiDataProvider<T, TCollection> : IApiProvider<T, TCollection>
    {
        private string _baseUrl;
        private string _resourcePath;

        public BaseRestApiDataProvider(string baseUrl, string resourcePath)
        {
            _baseUrl = baseUrl;
            _resourcePath = resourcePath;
        }


        public async Task<TCollection> GetAllAsync()
        {
            var data = await GetResourceAsync(_baseUrl + _resourcePath);

            var clients = JsonConvert.DeserializeObject<TCollection>(data);

            return clients;
        }

        private static async Task<string> GetResourceAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url)
                    .ConfigureAwait(false); ;
            }
        }
    }
}