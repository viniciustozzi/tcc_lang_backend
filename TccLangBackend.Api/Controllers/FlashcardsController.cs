using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Core.Flashcard;
using TccLangBackend.DB.Business;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/flashcards")]
    [ApiController]
    public class FlashcardsController : UtilControllerBase
    {
        private readonly FlashcardsBusiness _flashcardsBusiness;

        public FlashcardsController(FlashcardsBusiness flashcardsBusiness) => _flashcardsBusiness = flashcardsBusiness;

        [HttpGet]
        public IEnumerable<ModelFlashcard> GetFlashcards() => _flashcardsBusiness.GetFlashcards(UserId);

        [HttpGet("{id}")]
        public Task<ModelFlashcard> GetFlashcard(int id) => _flashcardsBusiness.GetFlashcard(UserId, id);

        [HttpPost]
        public Task SaveFlashcard([FromBody] CreateFlashcard request) => _flashcardsBusiness.Create(request);
    }
}