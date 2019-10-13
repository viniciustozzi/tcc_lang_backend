using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Auth;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthBusiness _authBusiness;

        public AuthController(AuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }


        [HttpPost]
        [AllowAnonymous]
        public Task<TokenResponse> Auth([FromBody] AuthRequest payload)
        {
            return _authBusiness.Authenticate(payload);
        }
    }
}