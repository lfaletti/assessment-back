using Insurance.IApiProviders.Models;

namespace Insurance.ApiProviders.Providers
{
    public class PolicyDataProvider<T, TCollection> : ApiDataProviderBase<Policy, PolicyCollection>
    {
        public PolicyDataProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath) { }
    }
}