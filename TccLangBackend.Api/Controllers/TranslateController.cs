using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Business;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/translate")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private readonly TranslationBusiness _translationBusiness;

        public TranslateController(TranslationBusiness translationBusiness) =>
            _translationBusiness = translationBusiness;

        [HttpGet]
        public Task<Translation> Get([FromQuery] string text) => _translationBusiness.Translate(text);
    }
}