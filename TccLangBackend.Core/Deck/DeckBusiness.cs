using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.Core.Deck
{
    public class DeckBusiness
    {
        private readonly IDeckRepository _deckRepository;
        private readonly FlashcardsBusiness _flashcardsBusiness;

        public DeckBusiness(IDeckRepository deckRepository, FlashcardsBusiness flashcardsBusiness)
        {
            _deckRepository = deckRepository;
            _flashcardsBusiness = flashcardsBusiness;
        }

        public Task<SummaryDeck> CreateAsync(CreateDeck createDeck)
        {
            return _deckRepository.CreateAsync(createDeck);
        }


        public IEnumerable<SummaryDeck> GetAll(int userId)
        {
            return _deckRepository.GetAll(userId);
        }

        public async Task<DetailedDeck> GetAsync(int userId, int deckId)
        {
            var detailedDeck = await _deckRepository.GetAsync(userId, deckId);
            var flashcardToday = await _flashcardsBusiness.GetFlashcardToday(userId, deckId);
            detailedDeck.FlashcardsToday = flashcardToday.Count();
            return detailedDeck;
        }

        public Task<DetailedDeck> GetByTextIdAsync(int userId, int textId)
        {
            return _deckRepository.GetByTextIdAsync(userId, textId);
        }
    }
}