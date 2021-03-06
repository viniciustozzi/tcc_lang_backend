using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Auth;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AuthBusiness _authBusiness;

        public RegisterController(AuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }


        [HttpPost]
        [AllowAnonymous]
        public Task Register([FromBody] RegisterRequest request)
        {
            return _authBusiness.Register(request);
        }
    }
}