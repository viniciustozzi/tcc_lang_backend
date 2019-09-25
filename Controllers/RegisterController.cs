using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc_lang_backend.Business;

namespace tcc_lang_backend.Controllers
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
        public Task Register([FromBody] RegisterRequest request)
        {
            return _authBusiness.Register(request);
        }
    }
}