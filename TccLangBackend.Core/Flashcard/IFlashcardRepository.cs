using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Flashcard
{
    public interface IFlashcardRepository
    {
        IEnumerable<ModelFlashcard> GetAll(int userId, int deckId);

        Task<ModelFlashcard> FindAsync(int flashcardId);

        Task<ModelFlashcard> CreateAsync(CreateFlashcard createFlashcard);

        Task DeleteByOriginalWordAsync(int userId, int deckId, string originalWord);

        Task CreateLogAsync(CreateLog createLog);
        Task<ModelFlashcardLog> GetLastLogAsync(int flashcardId);
        Task<double> GetEasinessFactorByIdAsync(int createLogFlashcardId);
        Task UpdateFlashcardById(int flashcardId, double ef, int days);
    }
}