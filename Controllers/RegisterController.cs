using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Business;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AuthBusiness _authBusiness;

        public RegisterController(AuthBusiness authBusiness) => _authBusiness = authBusiness;

        [HttpPost]
        public Task Register([FromBody] RegisterRequest request) => _authBusiness.Register(request);
    }
}