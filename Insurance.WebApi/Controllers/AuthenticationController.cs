using Insurance.IServices.Authentication;
using Insurance.WebApi.Models.Authentication;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;
namespace Insurance.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthenticationController : ApiController
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Authorize(Roles = "admin")]
        [Route("users")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await _authenticationService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Ping method to test authenticated user.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("ping")]
        [HttpGet]
        public IHttpActionResult Ping()
        {
            return Ok(true);
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authenticationService.Register(model.UserName, model.Password);

            return HandleResult(result);
        }



        protected IHttpActionResult HandleResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return Ok();
            }
            return null;
        }

    }
}