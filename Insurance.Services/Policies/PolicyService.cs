using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Policies;
using Insurance.IApiProviders.Providers;
using Insurance.IServices.ServiceModels;
using Insurance.IServices.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.IServices.Policies
{
    public class PolicyService : IPolicyService
    {
        IPoliciesProvider<PolicyServiceModel> _policyProvider;
        IClientsProvider<ClientServiceModel> _clientsProvider;

        public PolicyService(IPoliciesProvider<PolicyServiceModel> policyDataProvider,
            IClientsProvider<ClientServiceModel> clientsProvider)
        {
            this._policyProvider = policyDataProvider;
            this._clientsProvider = clientsProvider;
        }

        public async Task<List<PolicyViewModel>> GetAllAsync()
        {
            return AutoMapper.Mapper.Map<List<PolicyViewModel>>(await _policyProvider.GetAllAsync());

        }

        public async Task<List<PolicyViewModel>> GetByUsernameAsync(string userName)
        {
            // Get id of the client with username
            var clientData = await _clientsProvider.GetByUserNameAsync(userName).ConfigureAwait(false);

            // Get from policy provider
            var policyData = await _policyProvider.GetPoliciesByClientId(clientData.Id);

            return AutoMapper.Mapper.Map<List<PolicyViewModel>>(policyData);
        }
    }
}
