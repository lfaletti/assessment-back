using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.ApiProviders.ViewModels;

namespace Insurance.ApiProviders.IPolicies
{
    public interface IPolicyService
    {
        Task<List<PolicyViewModel>> GetAllAsync();
        Task<List<PolicyViewModel>> GetByUsernameAsync(string userName);
    }
}