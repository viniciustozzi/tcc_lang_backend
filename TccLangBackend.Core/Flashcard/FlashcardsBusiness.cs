using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Flashcard
{
    public class FlashcardsBusiness
    {
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardsBusiness(IFlashcardRepository flashcardRepository) =>
            _flashcardRepository = flashcardRepository;

        public IEnumerable<ModelFlashcard> GetFlashcards(int userId, int deckId) =>
            _flashcardRepository.GetAll(userId, deckId);

        public Task<ModelFlashcard> GetFlashcard(int userId, int deckId, int flashcardId) =>
            _flashcardRepository.FindAsync(userId, deckId, flashcardId);

        public Task<ModelFlashcard> Create(CreateFlashcard createFlashcard) =>
            _flashcardRepository.CreateAsync(createFlashcard);

        public Task DeleteAsync(int userId, int deckId, int flashcardId) =>
            _flashcardRepository.DeleteAsync(userId, deckId, flashcardId);
    }
}