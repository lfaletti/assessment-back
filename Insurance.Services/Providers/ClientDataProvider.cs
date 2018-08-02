using Insurance.Services.Models;

namespace Insurance.Services.Providers
{
    public class ClientDataProvider<T, TCollection> : BaseRestApiDataProvider<Client, ClientCollection>
    {
        public ClientDataProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath) { }
    }
}