using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Policies;
using Insurance.IServices.IClients;
using Insurance.IServices.ServiceModels;
using Insurance.IServices.ViewModels;

namespace Insurance.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientsProvider<ClientServiceModel> _clientProvider;
        private readonly IPoliciesProvider<PolicyServiceModel> _policyProvider;

        public ClientService(
            IClientsProvider<ClientServiceModel> clientDataProvider,
            IPoliciesProvider<PolicyServiceModel> policyProvider)
        {
            _clientProvider = clientDataProvider;
            _policyProvider = policyProvider;
        }

        public async Task<List<ClientViewModel>> GetAllAsync()
        {
            return Mapper.Map<List<ClientViewModel>>(await _clientProvider.GetAllAsync());
        }

        public async Task<ClientViewModel> GetByIdAsync(string id)
        {
            return Mapper.Map<ClientViewModel>(await _clientProvider.GetAsync(id));
        }

        public async Task<ClientViewModel> GetByPolicyNumber(string policyNumber)
        {
            var policy = await _policyProvider.GetAsync(policyNumber).ConfigureAwait(false);

            return Mapper.Map<ClientViewModel>(await _clientProvider.GetAsync(policy.ClientId));
        }

        public async Task<ClientViewModel> GetByUserAsync(string userName)
        {
            return Mapper.Map<ClientViewModel>(await _clientProvider.GetByUserNameAsync(userName));
        }
    }
}