using Insurance.Services.Models;

namespace Insurance.Services.Providers
{
    public class PolicyDataProvider<T, TCollection> : BaseRestApiDataProvider<Policy, PolicyCollection>
    {
        public PolicyDataProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath) { }
    }
}