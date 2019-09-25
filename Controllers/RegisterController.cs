using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.DB.Business;

namespace TccLangBackend.DB.Controllers
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