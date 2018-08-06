using Insurance.IApiProviders.Providers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.ApiProviders
{
    /// <summary>
    ///  A generic Base class to get insurance REST external resources
    ///  Assumptions: response models map exactly to model defined in IServices projects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiDataProviderBase<T, TCollection> : IApiProvider<T, TCollection>
    {
        private string _baseUrl;
        private string _resourcePath;

        public ApiDataProviderBase(string baseUrl, string resourcePath)
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

        public Task<T> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(T t)
        {
            throw new System.NotImplementedException();
        }
    }
}