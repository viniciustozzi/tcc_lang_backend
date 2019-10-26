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
                .Select(x => new ModelFlashcard(x.Id, x.OriginalWord, x.TranslatedWord));
        }

        public Task<ModelFlashcard> FindAsync(int userId, int deckId, int flashcardId)
        {
            return _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Id == flashcardId && x.DeckId == deckId && x.Deck.UserId == userId)
                .Select(x => new ModelFlashcard(x.Id, x.OriginalWord, x.TranslatedWord))
                .FirstOrDefaultAsync();
        }

        public async Task<ModelFlashcard> CreateAsync(CreateFlashcard createFlashcard)
        {
            var flashcard = new Flashcard
            {
                DeckId = createFlashcard.DeckId,
                OriginalWord = createFlashcard.OriginalWord,
                TranslatedWord = createFlashcard.TranslatedWord
            };

            _dbContext.Flashcards.Add(flashcard);

            await _dbContext.SaveChangesAsync();

            return new ModelFlashcard(flashcard.Id, flashcard.OriginalWord, flashcard.TranslatedWord);
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
    }
}