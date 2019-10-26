using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Flashcard
{
    public class FlashcardsBusiness
    {
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardsBusiness(IFlashcardRepository flashcardRepository)
        {
            _flashcardRepository = flashcardRepository;
        }

        public IEnumerable<ModelFlashcard> GetFlashcards(int userId, int deckId)
        {
            return _flashcardRepository.GetAll(userId, deckId);
        }

        public Task<ModelFlashcard> GetFlashcard(int userId, int deckId, int flashcardId)
        {
            return _flashcardRepository.FindAsync(userId, deckId, flashcardId);
        }

        public Task<ModelFlashcard> Create(CreateFlashcard createFlashcard)
        {
            return _flashcardRepository.CreateAsync(createFlashcard);
        }

        public Task CreateLogAsync(CreateLog createLog)
        {
            return _flashcardRepository.CreateLogAsync(createLog);
        }

        public Task DeleteAsync(int userId, int deckId, int flashcardId)
        {
            return _flashcardRepository.DeleteAsync(userId, deckId, flashcardId);
        }
    }
}