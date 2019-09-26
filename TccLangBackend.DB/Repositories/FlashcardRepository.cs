using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Flashcard;
using TccLangBackend.DB.Business;

namespace TccLangBackend.DB.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly TccDbContext _dbContext;

        public FlashcardRepository(TccDbContext dbContext) => _dbContext = dbContext;

        public IEnumerable<ModelFlashcard> GetAll(int userId) =>
            _dbContext.Flashcards
                .Include(x => x.Deck)
                .Where(x => x.Deck.UserId == userId)
                .Select(x => new ModelFlashcard(x.Id, x.Title));

        public Task<ModelFlashcard> FindAsync(int userId, int flashcardId) =>
            throw new NotImplementedException();

        public Task CreateAsync(CreateFlashcard createFlashcard) => throw new NotImplementedException();
    }
}