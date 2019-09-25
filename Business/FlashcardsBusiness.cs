using System.Collections.Generic;
using System.Threading.Tasks;
using TccLangBackend.DB.DB;
using TccLangBaekend.DB;

namespace TccLangBackend.DB.Business
{
    public class FlashcardsBusiness
    {
        private readonly TccDbContext _dbContext;

        public FlashcardsBusiness(TccDbContext dbContext) => _dbContext = dbContext;

        public IEnumerable<Flashcard> GetFlashcards() => _dbContext.Flashcards;

        public Task<Flashcard> GetFlashcard(int id) => _dbContext.Flashcards.FindAsync(id);

        public async Task SaveFlashcard(FlashcardRequest request)
        {
            var flashcard = new Flashcard
            {
                Id = request.Id,
                Title = request.Title
            };

            _dbContext.Flashcards.Add(flashcard);
            await _dbContext.SaveChangesAsync();
        }
    }


    public class FlashcardRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}