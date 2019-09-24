using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc_lang_backend.Business;
using tcc_lang_backend.DB;

namespace tcc_lang_backend.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextController : Controller
    {
        private readonly TextsBusiness _textsBusiness;

        public TextController(TextsBusiness textsBusiness)
        {
            _textsBusiness = textsBusiness;
        }

        [HttpGet]
        public IEnumerable GetTexts()
        {
            return _textsBusiness.GetTexts();
        }

        [HttpGet("{id}")]
        public Task<Text> GetText(int id)
        {
            return _textsBusiness.GetText(id);
        }

        [HttpPost]
        public Task<Text> SaveText([FromBody] TextRequest textRequest)
        {
            return _textsBusiness.SaveText(textRequest);
        }
    }
}