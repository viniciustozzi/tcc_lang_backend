using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Flashcard;
using Z.EntityFramework.Plus;

namespace TccLangBackend.Framework.DB.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly TccDbContext _dbContext;

        public FlashcardRepository(TccDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ModelFlashcard> GetAll(int userId, int deckId)
        {
            return _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Deck.UserId == userId && x.DeckId == deckId)
                .Select(x => new ModelFlashcard(x.Id, x.OriginalWord, x.TranslatedWord, x.EasinessFactor));
        }

        public Task<ModelFlashcard> FindAsync(int userId, int deckId, int flashcardId)
        {
            return _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Id == flashcardId && x.DeckId == deckId && x.Deck.UserId == userId)
                .Select(x => new ModelFlashcard(x.Id, x.OriginalWord, x.TranslatedWord, x.EasinessFactor))
                .FirstOrDefaultAsync();
        }

        public async Task<ModelFlashcard> CreateAsync(CreateFlashcard createFlashcard)
        {
            var flashcard = new Flashcard
            {
                DeckId = createFlashcard.DeckId,
                OriginalWord = createFlashcard.OriginalWord,
                TranslatedWord = createFlashcard.TranslatedWord,
                EasinessFactor = 2.5
            };

            _dbContext.Flashcards.Add(flashcard);

            await _dbContext.SaveChangesAsync();

            return new ModelFlashcard(flashcard.Id, flashcard.OriginalWord, flashcard.TranslatedWord,
                flashcard.EasinessFactor);
        }

        public Task DeleteByOriginalWordAsync(int userId, int deckId, string originalWord)
        {
            return _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.OriginalWord == originalWord && x.DeckId == deckId && x.Deck.UserId == userId)
                .DeleteAsync();
        }

        public Task CreateLogAsync(CreateLog createLog)
        {
            _dbContext.FlashcardLogs.Add(new FlashcardLog
            {
                CreationDateTime = createLog.CreationDateTime,
                FlashcardId = createLog.FlashcardId,
                Difficulty = createLog.Difficulty
            });

            return _dbContext.SaveChangesAsync();
        }

        public Task<ModelFlashcardLog> GetLastLogAsync(int flashcardId) =>
            _dbContext.FlashcardLogs
                .Where(x => x.FlashcardId == flashcardId)
                .OrderByDescending(x => x.CreationDateTime)
                .Select(x => new ModelFlashcardLog
                {
                    Difficulty = x.Difficulty,
                    Id = x.Id,
                    DateTime = x.CreationDateTime,
                    FlashcardId = x.FlashcardId
                })
                .FirstOrDefaultAsync();

        public Task<double> GetEasinessFactorByIdAsync(int flashcardId) =>
            _dbContext.Flashcards
                .Where(x => x.Id == flashcardId)
                .Select(x => x.EasinessFactor)
                .FirstOrDefaultAsync();

        public Task UpdateFlashcardEfById(int flashcardId, double ef)
        {
            var flashcard = new Flashcard
            {
                Id = flashcardId,
                EasinessFactor = ef
            };

            _dbContext.Flashcards.Attach(flashcard);
            _dbContext.Entry(flashcard).Property(e => e.EasinessFactor).IsModified = true;
            return _dbContext.SaveChangesAsync();
        }
    }
}