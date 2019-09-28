using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Controllers.Requests;
using TccLangBackend.Core.Deck;
using TccLangBackend.Core.Text;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextController : UtilControllerBase
    {
        private readonly DeckBusiness _deckBusiness;
        private readonly TextBusiness _textBusiness;

        public TextController(TextBusiness textBusiness, DeckBusiness deckBusiness)
        {
            _textBusiness = textBusiness;
            _deckBusiness = deckBusiness;
        }

        [HttpGet]
        public IEnumerable<SummaryText> GetTexts() => _textBusiness.GetAll(UserId);

        [HttpPost]
        public Task SaveText([FromBody] CreateTextRequest createTextRequest) =>
            _textBusiness.CreateAsync(new CreateText(createTextRequest.Words, UserId, createTextRequest.Title));

        [HttpGet("{textId}")]
        public Task<DetailedText> GetText(int textId) => _textBusiness.GetAsync(UserId, textId);
    }
}