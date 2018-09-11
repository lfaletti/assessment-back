using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Insurance.IApiProviders.Models;
using Insurance.IApiProviders.Policies;
using Insurance.ApiProviders.ServiceModels;
using Newtonsoft.Json;

namespace Insurance.ApiProviders.Policies
{
    public class PoliciesProvider<T> : ApiDataProviderBase<PolicyServiceModel>, IPoliciesProvider<PolicyServiceModel>
    {
        public PoliciesProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath)
        {
        }

        public Task AddAsync(PolicyServiceModel t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PolicyServiceModel>> GetAllAsync()
        {
            try
            {
                var data = await GetResourceAsync();

                var policies = JsonConvert.DeserializeObject<PolicyResponse<PolicyDTO>>(data);

                return Mapper.Map<List<PolicyServiceModel>>(policies.Policies);
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
                var result = await GetAllAsync().ConfigureAwait(false);

                return result.Where(c => c.Id != null && c.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Get Policies by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<List<PolicyServiceModel>> GetPoliciesByClientId(string clientId)
        {
            try
            {
                // Without REST operation to get policies by ClientId, get all policies from service and filter out 
                var allPolicies = await GetAllAsync().ConfigureAwait(false);

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