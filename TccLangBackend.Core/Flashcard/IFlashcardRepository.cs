using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Flashcard
{
    public interface IFlashcardRepository
    {
        IEnumerable<ModelFlashcard> GetAll(int userId);

        Task<ModelFlashcard> FindAsync(int userId, int flashcardId);

        Task CreateAsync(CreateFlashcard createFlashcard);
    }
}