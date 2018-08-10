using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.IApiProviders.Policies
{
    public interface IPoliciesProvider<T> : IApiProvider<T>
    {
        Task<List<T>> GetPoliciesByClientId(string clientId);
    }
}