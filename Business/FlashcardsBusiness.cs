using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_lang_backend.DB;

namespace tcc_lang_backend.Business
{
    public class FlashcardsBusiness
    {
        private readonly TccDbContext _dbContext;

        public FlashcardsBusiness(TccDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Flashcard> GetFlashcards()
        {
            return _dbContext.Flashcards.AsEnumerable();
        }

        public Task<Flashcard> GetFlashcard(int id)
        {
            return _dbContext.Flashcards.FindAsync(id);
        }

        public async Task SaveFlashcard(FlashcardRequest request)
        {
            var flashcard = new Flashcard()
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
        public String Title { get; set; }
    }
}