using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Text
{
    public class TextBusiness
    {
        private readonly ITextRepository _textRepository;

        public TextBusiness(ITextRepository textRepository)
        {
            _textRepository = textRepository;
        }

        public IEnumerable<SummaryText> GetFeed()
        {
            return _textRepository.GetFeed();
        }

        public IEnumerable<SummaryText> GetBookmarks(int userId)
        {
            return _textRepository.GetBookmarks(userId);
        }
        
        public Task<DetailedText> GetAsync(int userId, int textId)
        {
            return _textRepository.GetAsync(userId, textId);
        }

        public Task CreateAsync(CreateText createText)
        {
            return _textRepository.CreateAsync(createText);
        }

        public Task CreateBookmark(CreateBookmark createBookmark)
        {
            return _textRepository.CreateBookmark(createBookmark);
        }
    }
}