using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TccLangBackend.Core.Text;

namespace TccLangBackend.Core.Feed
{
    public class FeedBusiness
    {
        private readonly IRssFeedRepository _rssFeedRepository;
        private readonly TextBusiness _textBusiness;
        private static readonly List<FeedSource> Feeds;

        static FeedBusiness()
        {
            Feeds = new List<FeedSource>
            {
                new FeedSource("http://rss.dw.com/atom/rss-en-top", "en", FeedType.Atom),
                new FeedSource("http://rss.dw.com/atom/rss-de-top", "de", FeedType.Atom),
                new FeedSource("http://ep00.epimg.net/rss/elpais/portada.xml", "es", FeedType.Rss),
                new FeedSource("http://g1.globo.com/dynamo/rss2.xml", "pt", FeedType.Rss)
            };
        }

        public FeedBusiness(IRssFeedRepository rssFeedRepository, TextBusiness textBusiness)
        {
            _rssFeedRepository = rssFeedRepository;
            _textBusiness = textBusiness;
        }

        public IEnumerable<FeedSource> GetFeedSource() => Feeds;

        public async Task FillDatabaseWithBigData()
        {
            foreach (var source in Feeds)
            {
                var posts = await _rssFeedRepository.RetrieveAsync(source.Url, source.FeedType);
                foreach (var post in posts)
                {
                    try
                    {
                        await _textBusiness.CreateAsync(new CreateText(post.MainContent, post.Title, source.Lang));
                    }
                    catch (InvalidParamException)
                    {
                        //TODO: ignoring this error
                    }
                }
            }
        }
    }
}