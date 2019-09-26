using System.Threading.Tasks;
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
                UserId = createDeck.UserId
            });

            return _dbContext.SaveChangesAsync();
        }
    }
}