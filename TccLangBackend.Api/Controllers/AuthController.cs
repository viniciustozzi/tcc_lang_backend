using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Business;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthBusiness _authBusiness;

        public AuthController(AuthBusiness authBusiness) => _authBusiness = authBusiness;

        [HttpPost]
        public Task<TokenResponse> Auth([FromBody] AuthRequest payload) => _authBusiness.Authenticate(payload);
    }
}