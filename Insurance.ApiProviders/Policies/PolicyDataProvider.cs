using System.Threading.Tasks;
using Insurance.IApiProviders.Models;
using Insurance.IApiProviders.Policies;
using System.Linq;
using Insurance.IServices.ServiceModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Insurance.ApiProviders.Providers
{
    public class PoliciesProvider<T> : ApiDataProviderBase<PolicyServiceModel>, IPoliciesProvider<PolicyServiceModel>
    {
        public PoliciesProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath) { }

        public Task AddAsync(PolicyServiceModel t)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PolicyServiceModel>> GetAllAsync()
        {
            try
            {
                var data = await base.GetResourceAsync();

                var policies = JsonConvert.DeserializeObject<PolicyResponse<PolicyDTO>>(data);

                return AutoMapper.Mapper.Map<List<PolicyServiceModel>>(policies.Policies);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PolicyServiceModel> GetAsync(string id)
        {
            try
            {
                var result = await this.GetAllAsync().ConfigureAwait(false);

                return result.Where(c => c.Id != null && c.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Policies by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<List<PolicyServiceModel>> GetPoliciesByClientId(string clientId)
        {
            try
            {
                // Without REST operation to get policies by ClientId, get all policies from service and filter out 
                var allPolicies = await this.GetAllAsync().ConfigureAwait(false);

                var policies = new List<PolicyServiceModel>();

                policies.AddRange(allPolicies.Where(p => p.ClientId != null && p.ClientId == clientId).ToList());

                return policies;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}