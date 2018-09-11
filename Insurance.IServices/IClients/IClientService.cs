using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.ApiProviders.ViewModels;

namespace Insurance.ApiProviders.IClients
{
    public interface IClientService
    {
        Task<List<ClientViewModel>> GetAllAsync();

        Task<ClientViewModel> GetByIdAsync(string id);
        Task<ClientViewModel> GetByUserAsync(string userName);
        Task<ClientViewModel> GetByPolicyNumber(string policyNumber);
    }
}