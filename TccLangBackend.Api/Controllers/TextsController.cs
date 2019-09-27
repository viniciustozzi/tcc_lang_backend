using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Controllers.Requests;
using TccLangBackend.Core.Text;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextController : UtilControllerBase
    {
        private readonly TextBusiness _textBusiness;

        public TextController(TextBusiness textBusiness) => _textBusiness = textBusiness;

        [HttpGet]
        public IEnumerable<ModelText> GetTexts() => _textBusiness.GetAll(UserId);

        [HttpGet("{id}")]
        public Task<ModelText> GetText(int id) => _textBusiness.GetAsync(UserId, id);

        [HttpPost]
        public Task SaveText([FromBody] TextRequest textRequest) =>
            _textBusiness.CreateAsync(new CreateText(textRequest.Words, UserId, textRequest.Title));
    }
}