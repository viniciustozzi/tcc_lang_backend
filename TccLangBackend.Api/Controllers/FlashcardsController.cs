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
    public class FlashcardsController : ControllerBase
    {
        private readonly FlashcardsBusiness _flashcardsBusiness;
        private readonly int _userId;

        public FlashcardsController(FlashcardsBusiness flashcardsBusiness)
        {
            var stringUserId = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            _userId = int.Parse(stringUserId);
            _flashcardsBusiness = flashcardsBusiness;
        }

        [HttpGet]
        public IEnumerable<ModelFlashcard> GetFlashcards() => _flashcardsBusiness.GetFlashcards(_userId);

        [HttpGet("{id}")]
        public Task<ModelFlashcard> GetFlashcard(int id) => _flashcardsBusiness.GetFlashcard(_userId, id);

        [HttpPost]
        public Task SaveFlashcard([FromBody] CreateFlashcard request) => _flashcardsBusiness.Create(request);
    }
}