using Insurance.IApiProviders.Providers;
using System.Threading.Tasks;

namespace Insurance.IApiProviders.Clients
{
    public interface IClientsProvider<T> : IApiProvider<T> 
    {
        Task<T> GetByUserNameAsync(string userName);
    }
}
