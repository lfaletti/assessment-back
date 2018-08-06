using Insurance.IApiProviders.Providers;
using Insurance.IServices.Clients;
using Insurance.IServices.Models;
using System.Threading.Tasks;

namespace Insurance.Services.Clients
{
    public class ClientService: IClientService
    {
        IApiProvider<Client, ClientCollection> _provider;

        public ClientService(IApiProvider<Client, ClientCollection> clientDataProvider)
        {
            _provider = clientDataProvider;
        }

        public async Task<ClientCollection> GetAllAsync()
        {
            return await _provider.GetAllAsync();
        }

        public async Task<Client> GetByIdAsync(string id)
        {
            return await _provider.GetAsync(id);
        }

        public async Task<Client> GetByPolicyNumberAsync(string policyNumber)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Client> GetByUserNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}