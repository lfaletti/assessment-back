using Insurance.IServices.Clients;
using Insurance.IServices.ServiceModels;
using Insurance.Services.Clients;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Insurance.WebApi.Controllers
{
    [RoutePrefix("api/insurance")]
    public class InsuranceController : ApiController
    {
        public IClientService _clientService;

        public InsuranceController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Insurance/Clients
        [Route("clients")]
        [Authorize]
        public async Task<IHttpActionResult> GetClients()
        {
            try
            {
                var clients = await _clientService.GetAllAsync();

                if (clients != null)
                {
                    return Ok(clients);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [Route("clients/{id:int}")] 
        [Authorize]
        [ResponseType(typeof(ClientServiceModel))]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var client = await _clientService.GetByIdAsync(id);
                
                if (client != null)
                {
                    return Ok(client);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
