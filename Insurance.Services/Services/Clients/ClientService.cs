using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Providers;
using Insurance.IServices.Clients;
using Insurance.IServices.ServiceModels;
using Insurance.IServices.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Services.Clients
{
    public class ClientService: IClientService
    {
        IClientsProvider<ClientServiceModel> _provider;

        public ClientService(IClientsProvider<ClientServiceModel> clientDataProvider)
        {
            _provider = clientDataProvider;
        }

        public async Task<List<ClientViewModel>> GetAllAsync()
        {
            return AutoMapper.Mapper.Map<List<ClientViewModel>>(await _provider.GetAllAsync());
            
        }

        public async Task<ClientViewModel> GetByIdAsync(string id)
        {
            return AutoMapper.Mapper.Map <ClientViewModel> (await _provider.GetAsync(id));
        }

        public async Task<ClientViewModel> GetByPolicyNumber(string policyNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<ClientViewModel> GetByUserAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}