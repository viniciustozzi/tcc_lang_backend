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

        public IEnumerable<SummaryText> GetFeed(string lang)
        {
            return _textRepository.GetFeed(lang);
        }

        public IEnumerable<SummaryText> GetBookmarks(int userId)
        {
            return _textRepository.GetBookmarks(userId);
        }

        public Task<DetailedText> GetAsync(int userId, int textId)
        {
            return _textRepository.GetAsync(userId, textId);
        }

        public async Task CreateAsync(CreateText createText)
        {
            var existByTile = await _textRepository.ExistByTileAsync(createText.Title);
            if (!existByTile)
                await _textRepository.CreateAsync(createText);
        }

        public Task CreateBookmark(CreateBookmark createBookmark)
        {
            return _textRepository.CreateBookmark(createBookmark);
        }
    }
}