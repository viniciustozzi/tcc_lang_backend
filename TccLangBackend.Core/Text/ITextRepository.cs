using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Text
{
    public interface ITextRepository
    {
        IEnumerable<SummaryText> GetFeed();
        Task<DetailedText> GetAsync(int userId, int textId);
        Task CreateAsync(CreateText createText);
        Task CreateBookmark(CreateBookmark createBookmark);
        IEnumerable<SummaryText> GetBookmarks(int userId);
    }
}