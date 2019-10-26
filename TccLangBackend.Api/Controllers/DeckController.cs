using System;
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
        public IEnumerable<SummaryDeck> GetAll()
        {
            return _deckBusiness.GetAll(UserId);
        }

        [HttpPost]
        public Task<SummaryDeck> Create([FromBody] CreateDeckRequest createDeckRequest)
        {
            return _deckBusiness.CreateAsync(new CreateDeck(UserId, createDeckRequest.Title, createDeckRequest.TextId));
        }

        [HttpGet("{deckId}")]
        public Task<DetailedDeck> GetAsync(int deckId)
        {
            return _deckBusiness.GetAsync(UserId, deckId);
        }

        [HttpGet("{deckId}/flashcards")]
        public IEnumerable<ModelFlashcard> GetFlashcards(int deckId)
        {
            return _flashcardsBusiness.GetFlashcards(UserId, deckId);
        }

        [HttpPost("{deckId}/flashcards")]
        public Task<ModelFlashcard> CreateFlashcard(int deckId,
            [FromBody] CreateFlashcardRequest createFlashcardRequest)
        {
            return _flashcardsBusiness.Create(new CreateFlashcard(UserId, deckId, createFlashcardRequest.OriginalWord,
                createFlashcardRequest.TranslatedWord));
        }

        [HttpGet("{deckId}/flashcards/{flashcardId}")]
        public Task<ModelFlashcard> GetFlashcard(int deckId, int flashcardId)
        {
            return _flashcardsBusiness.GetFlashcard(UserId, deckId, flashcardId);
        }

        [HttpDelete("{deckId}/flashcards/{originalWord}")]
        public Task DeleteCard(int deckId, string originalWord)
        {
            return _flashcardsBusiness.DeleteByOriginalWord(UserId, deckId, originalWord);
        }

        [HttpPost("{deckId}/flashcards/{flashcardId}/logs/{difficulty}")]
        public Task CreateFlashcardLog(int deckId, int flashcardId, Difficulty difficulty)
        {
            return _flashcardsBusiness.CreateLogAsync(new CreateLog(flashcardId, difficulty, DateTime.Now));
        }
    }
}