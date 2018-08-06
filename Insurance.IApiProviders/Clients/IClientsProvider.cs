using Insurance.IApiProviders.Providers;

namespace Insurance.IApiProviders.Clients
{
    public interface IClientsProvider<T, TCollection> : IApiProvider<T, TCollection> 
    {
    }
}
