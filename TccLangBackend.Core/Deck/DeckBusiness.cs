using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Deck
{
    public class DeckBusiness
    {
        private readonly IDeckRepository _deckRepository;

        public DeckBusiness(IDeckRepository deckRepository) => _deckRepository = deckRepository;

        public Task CreateAsync(CreateDeck createDeck) => _deckRepository.CreateAsync(createDeck);


        public IEnumerable<SummaryDeck> GetAll(int userId) => _deckRepository.GetAll(userId);

        public Task<DetailedDeck> GetAsync(int userId, int deckId) => _deckRepository.GetAsync(userId, deckId);

        public Task<DetailedDeck> GetByTextIdAsync(int userId, int textId) =>
            _deckRepository.GetByTextIdAsync(userId, textId);
    }
}