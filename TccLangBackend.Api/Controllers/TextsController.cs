using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Business;
using TccLangBackend.DB;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly TextsBusiness _textsBusiness;

        public TextController(TextsBusiness textsBusiness) => _textsBusiness = textsBusiness;

        [HttpGet]
        public IEnumerable GetTexts() => _textsBusiness.GetTexts();

        [HttpGet("{id}")]
        public Task<Text> GetText(int id) => _textsBusiness.GetText(id);

        [HttpPost]
        public Task<Text> SaveText([FromBody] TextRequest textRequest) => _textsBusiness.SaveText(textRequest);
    }
}