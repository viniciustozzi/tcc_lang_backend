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
        private readonly TextBusiness _textBusiness;
        private readonly DeckBusiness _deckBusiness;

        public TextController(TextBusiness textBusiness, DeckBusiness deckBusiness)
        {
            _textBusiness = textBusiness;
            _deckBusiness = deckBusiness;
        }

        [HttpGet]
        public IEnumerable<ModelText> GetTexts() => _textBusiness.GetAll(UserId);

        [HttpPost]
        public Task SaveText([FromBody] CreateTextRequest createTextRequest) =>
            _textBusiness.CreateAsync(new CreateText(createTextRequest.Words, UserId, createTextRequest.Title));

        [HttpGet("{id}")]
        public Task<ModelText> GetText(int id) => _textBusiness.GetAsync(UserId, id);


        [HttpGet("{textId}/deck")]
        public Task<ModelDeck> GetDeck(int textId) => _deckBusiness.GetByTextIdAsync(UserId, textId);
    }
}