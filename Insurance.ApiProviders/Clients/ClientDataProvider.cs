using System.Threading.Tasks;
using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Models;
using System.Linq;
using System;
using Newtonsoft.Json;
using Insurance.IServices.ServiceModels;
using System.Collections.Generic;

namespace Insurance.ApiProviders.Clients
{
    public class ClientDataProvider<T> : ApiDataProviderBase<ClientServiceModel>, IClientsProvider<ClientServiceModel>
    {
        public ClientDataProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath) { }

        public async Task<List<ClientServiceModel>> GetAllAsync()
        {
            var data = await base.GetResourceAsync();

            var clients = JsonConvert.DeserializeObject<List<ClientDTO>>(data);

            return AutoMapper.Mapper.Map<List<ClientServiceModel>>( clients );
        }


        /// <summary>
        /// Query service for clients by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ClientServiceModel> GetByUserNameAsync(string userName)
        {
            try
            {
                // External Api doesn't support get by username, get all in-memory and then filter
                var result = this.GetAllAsync();
                return result.Result.Where(c => c.Name != null && c.Name == userName).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}