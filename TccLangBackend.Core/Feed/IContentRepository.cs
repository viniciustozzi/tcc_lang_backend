using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Feed
{
    public interface IContentRepository
    {
        Task<IEnumerable<Post>> RetrieveAsync(string url);
    }
}