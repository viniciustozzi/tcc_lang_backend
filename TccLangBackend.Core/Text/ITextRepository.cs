using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Text
{
    public interface ITextRepository
    {
        IEnumerable<SummaryText> GetFeed(string lang);
        Task<DetailedText> GetAsync(int userId, int textId);
        Task CreateAsync(CreateText createText);
        Task CreateBookmarkAsync(CreateBookmark createBookmark);
        IEnumerable<SummaryText> GetBookmarks(int userId);
        Task<bool> ExistByTileAsync(string textTitle);
        Task<bool> ExistAsync(int textId);
    }
}