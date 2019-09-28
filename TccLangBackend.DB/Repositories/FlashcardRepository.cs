using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Flashcard;

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
                .Select(x => new ModelFlashcard(x.Id, x.Title));

        public Task<ModelFlashcard> FindAsync(int userId, int deckId, int flashcardId) =>
            _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Id == flashcardId && x.DeckId == deckId && x.Deck.UserId == userId)
                .Select(x => new ModelFlashcard(x.Id, x.Title))
                .FirstOrDefaultAsync();

        public Task CreateAsync(CreateFlashcard createFlashcard)
        {
            _dbContext.Flashcards.Add(new Flashcard
            {
                DeckId = createFlashcard.DeckId,
                Title = createFlashcard.Title
            });

            return _dbContext.SaveChangesAsync();
        }
    }
}