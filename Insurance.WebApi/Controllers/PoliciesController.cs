using Insurance.IServices.Policies;
using Insurance.IServices.ServiceModels;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Insurance.WebApi4.Controllers
{
    [RoutePrefix("api/insurance/policies")]
    public class PoliciesController : ApiController
    {

        private IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService){
            this._policyService = policyService;
        }

        [Route("{username}")]
        [Authorize]
        [ResponseType(typeof(PolicyServiceModel))]
        public async Task<IHttpActionResult> GetByUserName(string username)
        {
            try
            {
                var client = await _policyService.GetByUsernameAsync(username);

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
