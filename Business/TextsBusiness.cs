using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.DB;
using TccLangBackend.DB;
using TccLangBaekend.DB;

namespace TccLangBackend.Api.Business
{
    public class TextsBusiness
    {
        private readonly TccDbContext _dbContext;

        public TextsBusiness(TccDbContext dbContext) => _dbContext = dbContext;

        public IEnumerable<Text> GetTexts() => _dbContext.Texts.AsEnumerable();

        public Task<Text> GetText(int id) => _dbContext.Texts.FindAsync(id);

        public async Task<Text> SaveText([FromBody] TextRequest textRequest)
        {
            var text = new Text
            {
                Title = textRequest.Title
            };
            _dbContext.Texts.Add(text);
            await _dbContext.SaveChangesAsync();

            return new TextResponse
            {
                Title = text.Title,
                Words = text.Words
            };
        }
    }

    public class TextResponse : Text
    {
        public string Title { get; set; }
        public string Words { get; set; }
    }

    public class TextRequest
    {
        public string Title { get; set; }
        public string WordSections { get; set; }
    }
}