using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Insurance.IServices.IPolicies;
using Insurance.IServices.ServiceModels;
using Insurance.WebApi.Handlers;

namespace Insurance.WebApi.Controllers
{
    [RoutePrefix("api/insurance/policies")]
    public class PoliciesController : ApiController
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [Route("{username}")]
        [Authorize(Roles = "admin,user")]
        [ResponseType(typeof(PolicyServiceModel))]
        public async Task<IHttpActionResult> GetByUserName(string username)
        {
            try
            {
                var client = await _policyService.GetByUsernameAsync(username);

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