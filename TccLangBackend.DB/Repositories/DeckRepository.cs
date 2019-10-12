using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Deck;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.DB.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly TccDbContext _dbContext;

        public DeckRepository(TccDbContext dbContext) => _dbContext = dbContext;

        public async Task<SummaryDeck> CreateAsync(CreateDeck createDeck)
        {
            var deck = new Deck
            {
                Title = createDeck.Title,
                UserId = createDeck.UserId,
                TextId = createDeck.TextId
            };
            _dbContext.Decks.Add(deck);

            await _dbContext.SaveChangesAsync();
            
            return new SummaryDeck(deck.Id, deck.Title, deck.TextId);
        }

        public IEnumerable<SummaryDeck> GetAll(int userId) =>
            _dbContext.Decks
                .Where(x => x.UserId == userId)
                .Select(x => new SummaryDeck(x.Id, x.Title, x.TextId));

        public Task<DetailedDeck> GetAsync(int userId, int deckId) =>
            _dbContext.Decks
                .Include(x => x.Flashcards)
                .Where(x => x.UserId == userId && x.Id == deckId)
                .Select(x => new DetailedDeck(x.Id, x.Title, x.TextId,
                    x.Flashcards.Select(y => new ModelFlashcard(y.Id, y.OriginalWord, y.TranslatedWord))))
                .FirstOrDefaultAsync();

        public Task<DetailedDeck> GetByTextIdAsync(int userId, int textId) =>
            _dbContext.Decks
                .Include(x => x.Flashcards)
                .Where(x => x.UserId == userId && x.TextId == textId)
                .Select(x => new DetailedDeck(x.Id, x.Title, x.TextId,
                    x.Flashcards.Select(y => new ModelFlashcard(y.Id, y.OriginalWord, y.TranslatedWord))))
                .FirstOrDefaultAsync();
    }
}