using System.Threading.Tasks;
using System.Web.Http;
using Insurance.ApiProviders.Identity;
using Insurance.WebApi.Models.Authentication;
using Microsoft.AspNet.Identity;

namespace Insurance.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IIdentityService _authenticationService;

        public AuthenticationController(IIdentityService authenticationService)
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
        ///     Ping method to test authenticated user.
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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authenticationService.Register(model.UserName, model.Password);

            return HandleResult(result);
        }


        protected IHttpActionResult HandleResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);

                if (ModelState.IsValid) return BadRequest();
            }

            return Ok();
        }
    }
}