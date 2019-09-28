using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Deck;

namespace TccLangBackend.DB.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly TccDbContext _dbContext;

        public DeckRepository(TccDbContext dbContext) => _dbContext = dbContext;

        public Task CreateAsync(CreateDeck createDeck)
        {
            _dbContext.Decks.Add(new Deck
            {
                Name = createDeck.Name,
                UserId = createDeck.UserId,
                TextId = createDeck.TextId
            });

            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<ModelDeck> GetAll(int userId) =>
            _dbContext.Decks
                .Where(x => x.UserId == userId)
                .Select(x => new ModelDeck(x.Id, x.Name, x.TextId));

        public Task<ModelDeck> GetAsync(int userId, int deckId) =>
            _dbContext.Decks
                .Where(x => x.UserId == userId && x.Id == deckId)
                .Select(x => new ModelDeck(x.Id, x.Name, x.TextId))
                .FirstOrDefaultAsync();

        public Task<ModelDeck> GetByTextIdAsync(int userId, int textId) =>
            _dbContext.Decks
                .Where(x => x.UserId == userId && x.TextId == textId)
                .Select(x => new ModelDeck(x.Id, x.Name, textId))
                .FirstOrDefaultAsync();
    }
}