using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.IServices.ViewModels;

namespace Insurance.IServices.IClients
{
    public interface IClientService
    {
        Task<List<ClientViewModel>> GetAllAsync();

        Task<ClientViewModel> GetByIdAsync(string id);
        Task<ClientViewModel> GetByUserAsync(string userName);
        Task<ClientViewModel> GetByPolicyNumber(string policyNumber);
    }
}