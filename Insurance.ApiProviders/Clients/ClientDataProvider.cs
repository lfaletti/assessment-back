using Insurance.IApiProviders.Models;

namespace Insurance.ApiProviders.Clients
{
    public class ClientDataProvider<T, TCollection> : ApiDataProviderBase<Client, ClientCollection>
    {
        public ClientDataProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath) { }
    }
}