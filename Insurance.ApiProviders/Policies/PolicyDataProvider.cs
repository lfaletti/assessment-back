using System.Threading.Tasks;
using Insurance.IApiProviders.Models;
using Insurance.IApiProviders.Policies;
using System.Linq;
using Insurance.IServices.ServiceModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Insurance.ApiProviders.Providers
{
    public class PoliciesProvider<T> : ApiDataProviderBase<PolicyServiceModel>, IPoliciesProvider<PolicyServiceModel>
    {
        public PoliciesProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath) { }

        public async Task<List<PolicyServiceModel>> GetAllAsync()
        {
            var data = await base.GetResourceAsync();

            var clients = JsonConvert.DeserializeObject<List<ClientDTO>>(data);

            return AutoMapper.Mapper.Map<List<PolicyServiceModel>>(clients);
        }

        /// <summary>
        /// Get Policies by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<List<PolicyServiceModel>> GetPoliciesByClientId(string clientId)
        {
            // Without REST operation to get policies by ClientId, get all policies from service and filter out 
            var allPolicies = this.GetAllAsync().Result;

            if (allPolicies != null)
            {
                var policies = new List<PolicyServiceModel>();

                policies.AddRange(allPolicies.Where(p => p.ClientId != null && p.ClientId == clientId).ToList());

                return policies;
            }
            return null;
        }
    }
}