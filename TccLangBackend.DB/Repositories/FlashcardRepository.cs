using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Flashcard;
using Z.EntityFramework.Plus;

namespace TccLangBackend.DB.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly TccDbContext _dbContext;

        public FlashcardRepository(TccDbContext dbContext) => _dbContext = dbContext;

        public IEnumerable<ModelFlashcard> GetAll(int userId, int deckId) =>
            _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Deck.UserId == userId && x.DeckId == deckId)
                .Select(x => new ModelFlashcard(x.Id, x.OriginalWord, x.TranslatedWord));

        public Task<ModelFlashcard> FindAsync(int userId, int deckId, int flashcardId) =>
            _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Id == flashcardId && x.DeckId == deckId && x.Deck.UserId == userId)
                .Select(x => new ModelFlashcard(x.Id, x.OriginalWord, x.TranslatedWord))
                .FirstOrDefaultAsync();

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

        public Task DeleteAsync(int userId, int deckId, int flashcardId) =>
            _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Id == flashcardId && x.DeckId == deckId && x.Deck.UserId == userId)
                .DeleteAsync();
    }
}