using System.Threading.Tasks;

namespace TccLangBackend.Core.Deck
{
    public class DeckBusiness
    {
        private readonly IDeckRepository _deckRepository;

        public DeckBusiness(IDeckRepository deckRepository) => _deckRepository = deckRepository;

        public Task CreateAsync(CreateDeck createDeck) => _deckRepository.CreateAsync(createDeck);
    }
}