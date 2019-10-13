using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TccLangBackend.Core.Text;

namespace TccLangBackend.Core.Feed
{
    public class FeedBusiness
    {
        private readonly IContentRepository _contentRepository;
        private readonly TextBusiness _textBusiness;
        private static readonly List<FeedSource> Feeds;

        static FeedBusiness()
        {
            Feeds = new List<FeedSource>
            {
                new FeedSource("http://rss.dw.com/atom/rss-en-top", "en"),
                new FeedSource("http://rss.dw.com/atom/rss-de-top", "de"),
            };
        }

        public FeedBusiness(IContentRepository contentRepository, TextBusiness textBusiness)
        {
            _contentRepository = contentRepository;
            _textBusiness = textBusiness;
        }

        public IEnumerable<FeedSource> GetFeedSource() => Feeds;

        public async Task FillDatabaseWithBigData()
        {
            foreach (var source in Feeds)
            {
                var posts = await _contentRepository.RetrieveAsync(source.Url);
                foreach (var post in posts)
                {
                    await _textBusiness.CreateAsync(new CreateText(post.MainContent, post.Title, source.Lang));
                }
            }
        }
    }
}