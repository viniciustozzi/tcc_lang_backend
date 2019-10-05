using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Deck
{
    public interface IDeckRepository
    {
        Task<SummaryDeck> CreateAsync(CreateDeck createDeck);

        IEnumerable<SummaryDeck> GetAll(int userId);

        Task<DetailedDeck> GetAsync(int userId, int deckId);
        Task<DetailedDeck> GetByTextIdAsync(int userId, int textId);
    }
}