using System.Collections.Generic;
using System.Threading.Tasks;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.DB.Business
{
    public class FlashcardsBusiness
    {
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardsBusiness(IFlashcardRepository flashcardRepository) =>
            _flashcardRepository = flashcardRepository;

        public IEnumerable<ModelFlashcard> GetFlashcards(int userId) => _flashcardRepository.GetAll(userId);

        public Task<ModelFlashcard> GetFlashcard(int userId, int flashcardId) =>
            _flashcardRepository.FindAsync(userId, flashcardId);

        public Task Create(CreateFlashcard createFlashcard) => _flashcardRepository.CreateAsync(createFlashcard);
    }
}