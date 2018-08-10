using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Policies;
using Insurance.IServices.IPolicies;
using Insurance.IServices.ServiceModels;
using Insurance.IServices.ViewModels;

namespace Insurance.Services.Policies
{
    public class PolicyService : IPolicyService
    {
        private readonly IClientsProvider<ClientServiceModel> _clientsProvider;
        private readonly IPoliciesProvider<PolicyServiceModel> _policyProvider;

        public PolicyService(IPoliciesProvider<PolicyServiceModel> policyDataProvider,
            IClientsProvider<ClientServiceModel> clientsProvider)
        {
            _policyProvider = policyDataProvider;
            _clientsProvider = clientsProvider;
        }

        public async Task<List<PolicyViewModel>> GetAllAsync()
        {
            return Mapper.Map<List<PolicyViewModel>>(await _policyProvider.GetAllAsync());
        }

        public async Task<List<PolicyViewModel>> GetByUsernameAsync(string userName)
        {
            // Get id of the client with username
            var clientData = await _clientsProvider.GetByUserNameAsync(userName).ConfigureAwait(false);

            // Get from policy provider
            var policyData = await _policyProvider.GetPoliciesByClientId(clientData.Id);

            return Mapper.Map<List<PolicyViewModel>>(policyData);
        }
    }
}