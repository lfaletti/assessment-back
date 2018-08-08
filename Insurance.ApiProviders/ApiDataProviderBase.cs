using Insurance.IApiProviders.Providers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.ApiProviders
{
    /// <summary>
    ///  A generic Base class to get insurance REST external resources
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiDataProviderBase<T>
    {
        private string _baseUrl;
        private string _resourcePath;

        public ApiDataProviderBase(string baseUrl, string resourcePath)
        {
            _baseUrl = baseUrl;
            _resourcePath = resourcePath;
        }


        protected async Task<string> GetResourceAsync()
        {
            var url = _baseUrl + _resourcePath;

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