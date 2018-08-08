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
        IApiProvider<PolicyServiceModel> _provider;
        IClientsProvider<ClientServiceModel> _clientsProvider;

        public PolicyService(IPoliciesProvider<PolicyServiceModel> policyDataProvider,
            IClientsProvider<ClientServiceModel> clientsProvider)
        {
            this._provider = policyDataProvider;
            this._clientsProvider = clientsProvider;
        }

        public async Task<List<PolicyViewModel>> GetAllAsync()
        {
            return AutoMapper.Mapper.Map<List<PolicyViewModel>>(await _provider.GetAllAsync());

        }

        public async Task<List<PolicyViewModel>> GetByUsernameAsync(string userName)
        {
            var clientData = _clientsProvider.GetByUserNameAsync(userName);

            var policyData = _provider.GetAllAsync().Result;

            return AutoMapper.Mapper.Map<List<PolicyViewModel>>(policyData.Where(p => p.ClientId != null &&
               clientData != null &&
               p.ClientId == userName).ToList());
        }
    }
}
