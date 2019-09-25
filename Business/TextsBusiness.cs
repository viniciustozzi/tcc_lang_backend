using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tcc_lang_backend.DB;

namespace tcc_lang_backend.Business
{
    public class TextsBusiness
    {
        private readonly TccDbContext _dbContext;

        public TextsBusiness(TccDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Text> GetTexts()
        {
            return _dbContext.Texts.AsEnumerable();
        }

        public Task<Text> GetText(int id)
        {
            return _dbContext.Texts.FindAsync(id);
        }

        public async Task<Text> SaveText([FromBody] TextRequest textRequest)
        {
            var text = new Text
            {
                Title = textRequest.Title,
            };
            _dbContext.Texts.Add(text);
            await _dbContext.SaveChangesAsync();

            return new TextResponse()
            {
                Title = text.Title,
                Words = text.Words
            };
        }
    }

    public class TextResponse : Text
    {
        public String Title { get; set; }
        public string Words { get; set; }
    }

    public class TextRequest
    {
        public string Title { get; set; }
        public string WordSections { get; set; }
    }
}