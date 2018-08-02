using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.Services.Models;

namespace Insurance.Services.Clients
{
    public interface IClientService
    {
        Task<ClientCollection> GetAllAsync();

        Client GetById(string id);
        Client GetByPolicyNumber(string policyNumber);
        Client GetByUserName(string userName);
    }
}