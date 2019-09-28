using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Deck
{
    public interface IDeckRepository
    {
        Task CreateAsync(CreateDeck createDeck);

        IEnumerable<ModelDeck> GetAll(int userId);

        Task<ModelDeck> GetAsync(int userId, int deckId);
        Task<ModelDeck> GetByTextIdAsync(int userId, int textId);
    }
}