using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Deck
{
    public class DeckBusiness
    {
        private readonly IDeckRepository _deckRepository;

        public DeckBusiness(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public Task<SummaryDeck> CreateAsync(CreateDeck createDeck)
        {
            return _deckRepository.CreateAsync(createDeck);
        }


        public IEnumerable<SummaryDeck> GetAll(int userId)
        {
            return _deckRepository.GetAll(userId);
        }

        public Task<DetailedDeck> GetAsync(int userId, int deckId)
        {
            return _deckRepository.GetAsync(userId, deckId);
        }

        public Task<DetailedDeck> GetByTextIdAsync(int userId, int textId)
        {
            return _deckRepository.GetByTextIdAsync(userId, textId);
        }
    }
}