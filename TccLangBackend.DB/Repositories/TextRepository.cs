using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.Text;

namespace TccLangBackend.DB.Repositories
{
    public class TextRepository : ITextRepository
    {
        private readonly TccDbContext _dbContext;

        public TextRepository(TccDbContext dbContext) => _dbContext = dbContext;

        public IEnumerable<ModelText> GetAll(int userId) =>
            _dbContext.Texts
                .Where(x => x.UserId == userId)
                .Select(x => new ModelText(x.Id, x.Title, x.Words));

        public Task<ModelText> GetAsync(int userId, int textId) =>
            _dbContext.Texts
                .Where(x => x.UserId == userId && x.Id == textId)
                .Select(x => new ModelText(x.Id, x.Title, x.Words))
                .FirstOrDefaultAsync();

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