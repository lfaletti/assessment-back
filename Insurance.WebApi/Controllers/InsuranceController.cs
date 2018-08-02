using Insurance.Services.Clients;
using System.Threading.Tasks;
using System.Web.Http;

namespace Insurance.WebApi4.Controllers
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
        public async Task<IHttpActionResult> GetClients()
        {
            var clients = await  _clientService.GetAllAsync();

            return Ok(clients);
        }   
    }
}
