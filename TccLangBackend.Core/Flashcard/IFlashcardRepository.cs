using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Flashcard
{
    public interface IFlashcardRepository
    {
        IEnumerable<ModelFlashcard> GetAll(int userId, int deckId);

        Task<ModelFlashcard> FindAsync(int userId, int deckId, int flashcardId);

        Task CreateAsync(CreateFlashcard createFlashcard);
    }
}