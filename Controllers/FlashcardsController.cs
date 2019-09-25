using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.DB.Business;
using TccLangBackend.DB.DB;

namespace TccLangBackend.DB.Controllers
{
    [Route("api/flashcards")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly FlashcardsBusiness _flashcardsBusiness;

        public FlashcardsController(FlashcardsBusiness flashcardsBusiness) => _flashcardsBusiness = flashcardsBusiness;

        [HttpGet]
        public IEnumerable<Flashcard> GetFlashcards() => _flashcardsBusiness.GetFlashcards();

        [HttpGet("{id}")]
        public Task<Flashcard> GetFlashcard(int id) => _flashcardsBusiness.GetFlashcard(id);

        [HttpPost]
        public Task SaveFlashcard([FromBody] FlashcardRequest request) => _flashcardsBusiness.SaveFlashcard(request);
    }
}