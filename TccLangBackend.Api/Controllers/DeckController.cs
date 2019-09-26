using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Controllers.Requests;
using TccLangBackend.Core.Deck;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/decks")]
    [ApiController]
    public class DeckController : UtilControllerBase
    {
        private readonly DeckBusiness _deckBusiness;

        public DeckController(DeckBusiness deckBusiness) => _deckBusiness = deckBusiness;

        [HttpGet]
        public IEnumerable<ModelDeck> GetAll() => _deckBusiness.GetAll(UserId);

        [HttpGet("{id}")]
        public Task<ModelDeck> GetAsync(int id) => _deckBusiness.GetAsync(UserId, id);

        [HttpPost]
        public Task Create([FromBody] CreateDeckRequest createDeckRequest) =>
            _deckBusiness.CreateAsync(new CreateDeck(UserId, createDeckRequest.Name));
    }
}