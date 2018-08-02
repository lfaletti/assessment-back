using Insurance.Services.Models;
using Insurance.Services.Providers;
using System.Collections.Generic;
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

        public Client GetById(string id)
        {
            return new Client();
        }

        public Client GetByUserName(string userName)
        {
            return new Client();
        }

        public Client GetByPolicyNumber(string policyNumber)
        {
            return new Client();
        }
    }
}