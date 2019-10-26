using System.Collections.Generic;
using System.Threading.Tasks;
using TccLangBackend.Core.User;

namespace TccLangBackend.Core.Text
{
    public class TextBusiness
    {
        private readonly ITextRepository _textRepository;
        private readonly IUserRepository _userRepository;

        public TextBusiness(ITextRepository textRepository, IUserRepository userRepository)
        {
            _textRepository = textRepository;
            _userRepository = userRepository;
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
            else
                throw new InvalidParamException(nameof(createText.Title), "A text with this title is already stored");
        }

        public async Task CreateBookmarkAsync(CreateBookmark createBookmark)
        {
            var textExist = await _textRepository.ExistAsync(createBookmark.TextId);
            if (!textExist)
                throw new NotFoundException("TextId not found");

            var userExist = await _userRepository.ExistAsync(createBookmark.UserId);
            if(!userExist)
                throw new NotFoundException("UserId not found");

            await _textRepository.CreateBookmarkAsync(createBookmark);
        }
    }
}