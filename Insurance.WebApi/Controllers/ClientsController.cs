using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Insurance.ApiProviders.IClients;
using Insurance.ApiProviders.Models;
using Insurance.WebApi.Handlers;

namespace Insurance.WebApi.Controllers
{
    [RoutePrefix("api/insurance/clients")]
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Insurance/Clients
        [Route("")]
        [Authorize(Roles = "admin,user")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var clients = await _clientService.GetAllAsync();

                if (clients != null) return Ok(clients);
                return NotFound();
            }
            catch (Exception ex)
            {
                WebApiExceptionHandler.HandleException(ex);
                return NotFound();
            }
        }

        [Route("{id}")]
        [Authorize(Roles = "admin,user")]
        [ResponseType(typeof(ClientServiceModel))]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var client = await _clientService.GetByIdAsync(id);

                if (client != null) return Ok(client);
                return NotFound();
            }
            catch (Exception ex)
            {
                WebApiExceptionHandler.HandleException(ex);
                return NotFound();
            }
        }

        [Route("name/{name}")]
        [Authorize(Roles = "admin,user")]
        [ResponseType(typeof(ClientServiceModel))]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            try
            {
                var client = await _clientService.GetByUserAsync(name);

                if (client != null) return Ok(client);
                return NotFound();
            }
            catch (Exception ex)
            {
                WebApiExceptionHandler.HandleException(ex);
                return NotFound();
            }
        }

        [Route("policies/{policyId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(ClientServiceModel))]
        public async Task<IHttpActionResult> GetByPolicyNumber(string policyId)
        {
            try
            {
                var client = await _clientService.GetByPolicyNumber(policyId);

                if (client != null) return Ok(client);
                return NotFound();
            }
            catch (Exception ex)
            {
                WebApiExceptionHandler.HandleException(ex);
                return NotFound();
            }
        }
    }
}