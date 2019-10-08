using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Deck;
using TccLangBackend.Core.Flashcard;
using TccLangBackend.Core.Text;

namespace TccLangBackend.DB.Repositories
{
    public class TextRepository : ITextRepository
    {
        private readonly TccDbContext _dbContext;

        public TextRepository(TccDbContext dbContext) => _dbContext = dbContext;

        public IEnumerable<SummaryText> GetAll(int userId) =>
            _dbContext.Texts
                .Where(x => x.UserId == userId)
                .Select(x => new SummaryText(x.Id, x.Title, x.Words));

        public async Task<DetailedText> GetAsync(int userId, int textId)
        {
            var queryable = _dbContext.Texts
                .Include(x => x.Deck)
                .Where(x => x.UserId == userId && x.Id == textId);

            var hasDeck = await _dbContext.Texts
                .Where(x => x.Id == textId)
                .Select(x => x.DeckId.HasValue)
                .FirstOrDefaultAsync();

            if (hasDeck)
                return await queryable
                    .Include(x => x.Deck)
                    .ThenInclude(x => x.Flashcards)
                    .Select(x => new DetailedText(x.Id, x.Title, x.Words,
                        new DetailedDeck(x.DeckId.Value, x.Deck.Title, x.Id,
                            x.Deck.Flashcards.Select(y => new ModelFlashcard(y.Id, y.OriginalWord, y.TranslatedWord)))))
                    .FirstOrDefaultAsync();

            return await queryable
                .Select(x => new DetailedText(x.Id, x.Title, x.Words, null))
                .FirstOrDefaultAsync();
        }

        public Task CreateAsync(CreateText createText)
        {
            _dbContext.Texts.Add(new Text
            {
                Title = createText.Title,
                UserId = createText.UserId,
                Words = createText.Words
            });

            return _dbContext.SaveChangesAsync();
        }
    }
}