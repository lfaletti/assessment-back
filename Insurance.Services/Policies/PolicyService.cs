using Insurance.Services.Models;
using Insurance.Services.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Services.Policies
{
    public class PolicyService : IPolicyService
    {
        IApiProvider<Policy, PolicyCollection> _provider;

        public PolicyService(IApiProvider<Policy, PolicyCollection> policyDataProvider)
        {
            _provider = policyDataProvider;
        }

        public async Task<PolicyCollection> GetAllAsync()
        {
            return await _provider.GetAllAsync();

        }

        public PolicyCollection GetByUsername(string userName)
        {
            var data = _provider.GetAllAsync().Result;

            return new PolicyCollection()
            {
                Policies = data.Policies.Where(p => p.ClientId == userName).ToList()
            };
        }
    }
}
