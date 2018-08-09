using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Policies;
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
        IClientsProvider<ClientServiceModel> _clientProvider;
        IPoliciesProvider<PolicyServiceModel> _policyProvider;

        public ClientService(
            IClientsProvider<ClientServiceModel> clientDataProvider,
            IPoliciesProvider<PolicyServiceModel> policyProvider)
        {
            _clientProvider = clientDataProvider;
            _policyProvider = policyProvider;
        }

        public async Task<List<ClientViewModel>> GetAllAsync()
        {
            return AutoMapper.Mapper.Map<List<ClientViewModel>>(await _clientProvider.GetAllAsync());
            
        }

        public async Task<ClientViewModel> GetByIdAsync(string id)
        {
            return AutoMapper.Mapper.Map <ClientViewModel> (await _clientProvider.GetAsync(id));
        }

        public async Task<ClientViewModel> GetByPolicyNumber(string policyNumber)
        {
            var policy = await _policyProvider.GetAsync(policyNumber).ConfigureAwait(false);

            return AutoMapper.Mapper.Map<ClientViewModel>(await _clientProvider.GetAsync(policy.ClientId));
        }

        public async Task<ClientViewModel> GetByUserAsync(string userName)
        {
            return AutoMapper.Mapper.Map<ClientViewModel>(await _clientProvider.GetByUserNameAsync(userName));
        }
    }
}