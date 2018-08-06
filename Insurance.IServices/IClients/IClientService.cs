using Insurance.IServices.Models;
using System.Threading.Tasks;

namespace Insurance.IServices.Clients
{
    public interface IClientService
    {
        Task<ClientCollection> GetAllAsync();

        Task<Client> GetByIdAsync(string id);
        Task<Client> GetByPolicyNumberAsync(string policyNumber);
        Task<Client> GetByUserNameAsync(string userName);
    }
}