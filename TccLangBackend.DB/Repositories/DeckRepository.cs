using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TccLangBackend.Core.Deck;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.DB.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly TccDbContext _dbContext;

        public DeckRepository(TccDbContext dbContext) => _dbContext = dbContext;

        public async Task CreateAsync(CreateDeck createDeck)
        {
            var deck = new Deck
            {
                Name = createDeck.Name,
                UserId = createDeck.UserId,
                TextId = createDeck.TextId
            };
            _dbContext.Decks.Add(deck);

            await _dbContext.SaveChangesAsync();

            if (createDeck.TextId.HasValue)
            {
                var entityEntry = _dbContext.Texts.Attach(new Text
                {
                    Id = createDeck.TextId.Value
                });

                entityEntry.Entity.DeckId = deck.Id;
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<SummaryDeck> GetAll(int userId) =>
            _dbContext.Decks
                .Where(x => x.UserId == userId)
                .Select(x => new SummaryDeck(x.Id, x.Name, x.TextId));

        public Task<DetailedDeck> GetAsync(int userId, int deckId) =>
            _dbContext.Decks
                .Include(x => x.Flashcards)
                .Where(x => x.UserId == userId && x.Id == deckId)
                .Select(x => new DetailedDeck(x.Id, x.Name, x.TextId,
                    x.Flashcards.Select(y => new ModelFlashcard(y.Id, y.Title))))
                .FirstOrDefaultAsync();

        public Task<DetailedDeck> GetByTextIdAsync(int userId, int textId) =>
            _dbContext.Decks
                .Include(x => x.Flashcards)
                .Where(x => x.UserId == userId && x.TextId == textId)
                .Select(x => new DetailedDeck(x.Id, x.Name, x.TextId,
                    x.Flashcards.Select(y => new ModelFlashcard(y.Id, y.Title))))
                .FirstOrDefaultAsync();
    }
}