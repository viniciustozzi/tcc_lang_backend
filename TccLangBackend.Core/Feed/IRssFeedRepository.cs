using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Feed
{
    public interface IRssFeedRepository
    {
        Task<IEnumerable<Post>> RetrieveAsync(string url, FeedType feedType);
    }
}