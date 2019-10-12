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

        public IEnumerable<SummaryText> GetAll() =>
            _dbContext.Texts
                .Select(x => new SummaryText(x.Id, x.Title, x.Words));

        public async Task<DetailedText> GetAsync(int userId, int textId)
        {
            var queryable = _dbContext.Texts
                .Where(x => x.Id == textId);

            var hasDeck = await _dbContext.Texts
                .Where(x => x.Id == textId)
                .Select(x => x.Decks.Any(y => y.UserId == userId))
                .FirstOrDefaultAsync();


            if (!hasDeck)
                return await queryable
                    .Select(x => new DetailedText(x.Id, x.Title, x.Words, null))
                    .FirstOrDefaultAsync();

            return await queryable
                .Include(x => x.Decks)
                .ThenInclude(x => x.Flashcards)
                .Select(x => new DetailedText(x.Id, x.Title, x.Words, x.Decks.Select(z => new DetailedDeck(z.Id,
                        z.Title, z.TextId,
                        z.Flashcards.Select(y => new ModelFlashcard(y.Id, y.OriginalWord, y.TranslatedWord))))
                    .First()))
                .FirstOrDefaultAsync();
        }

        public Task CreateAsync(CreateText createText)
        {
            _dbContext.Texts.Add(new Text
            {
                Title = createText.Title,
                Words = createText.Words
            });

            return _dbContext.SaveChangesAsync();
        }
    }
}