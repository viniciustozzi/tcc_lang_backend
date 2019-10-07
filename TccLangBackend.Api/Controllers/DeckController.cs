using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Controllers.Requests;
using TccLangBackend.Core.Deck;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/decks")]
    [ApiController]
    public class DeckController : UtilControllerBase
    {
        private readonly DeckBusiness _deckBusiness;
        private readonly FlashcardsBusiness _flashcardsBusiness;

        public DeckController(DeckBusiness deckBusiness, FlashcardsBusiness flashcardsBusiness)
        {
            _deckBusiness = deckBusiness;
            _flashcardsBusiness = flashcardsBusiness;
        }

        [HttpGet]
        public IEnumerable<SummaryDeck> GetAll() => _deckBusiness.GetAll(UserId);

        [HttpPost]
        public Task<SummaryDeck> Create([FromBody] CreateDeckRequest createDeckRequest) =>
            _deckBusiness.CreateAsync(new CreateDeck(UserId, createDeckRequest.Title, createDeckRequest.TextId));

        [HttpGet("{deckId}")]
        public Task<DetailedDeck> GetAsync(int deckId) => _deckBusiness.GetAsync(UserId, deckId);

        [HttpGet("{deckId}/flashcards")]
        public IEnumerable<ModelFlashcard> GetFlashcards(int deckId) =>
            _flashcardsBusiness.GetFlashcards(UserId, deckId);

        [HttpPost("{deckId}/flashcards")]
        public Task<ModelFlashcard> CreateFlashcard(int deckId, [FromBody] CreateFlashcardRequest createFlashcardRequest) =>
            _flashcardsBusiness.Create(new CreateFlashcard(UserId, deckId, createFlashcardRequest.OriginalText,
                createFlashcardRequest.TranslatedText));

        [HttpGet("{deckId}/flashcards/{flashcardId}")]
        public Task<ModelFlashcard> GetFlashcard(int deckId, int flashcardId) =>
            _flashcardsBusiness.GetFlashcard(UserId, deckId, flashcardId);
    }
}