using Insurance.IServices.ServiceModels;
using Insurance.IServices.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.IServices.Clients
{
    public interface IClientService
    {
        Task<List<ClientViewModel>> GetAllAsync();

        Task<ClientViewModel> GetByIdAsync(string id);
        Task<ClientViewModel> GetByUserAsync(string userName);
        Task<ClientViewModel> GetByPolicyNumber(string policyNumber);
    }
}