using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Models;
using Insurance.ApiProviders.ServiceModels;
using Newtonsoft.Json;
using Insurance.ApiProviders.ViewModels;

namespace Insurance.ApiProviders.Clients
{
    public class ClientDataProvider<T> : ApiDataProviderBase<ClientViewModel>, IClientsProvider<ClientServiceModel>
    {
        public ClientDataProvider(string baseUrl, string resourcePath) : base(baseUrl, resourcePath)
        {
        }

        public Task AddAsync(ClientServiceModel t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClientServiceModel>> GetAllAsync()
        {
            var data = await GetResourceAsync();

            var response = JsonConvert.DeserializeObject<ClientResponse<ClientDTO>>(data);

            return Mapper.Map<List<ClientServiceModel>>(response.Clients);
        }

        public async Task<ClientServiceModel> GetAsync(string id)
        {
            try
            {
                var result = await GetAllAsync().ConfigureAwait(false);

                return result.Where(c => c.Id != null && c.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///     Query service for clients by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ClientServiceModel> GetByUserNameAsync(string userName)
        {
            try
            {
                // External Api doesn't support get by username, get all in-memory and then filter
                var result = await GetAllAsync().ConfigureAwait(false);

                return result.Where(c => c.Name != null && c.Name == userName).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}