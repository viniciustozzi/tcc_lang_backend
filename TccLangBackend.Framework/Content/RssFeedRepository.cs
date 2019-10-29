using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using TccLangBackend.Core.Feed;
using static TccLangBackend.Core.Feed.FeedType;
using static TccLangBackend.Framework.Content.Tika;

namespace TccLangBackend.Framework.Content
{
    public class RssFeedRepository : IRssFeedRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RssFeedRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Post>> RetrieveAsync(string url, FeedType feedType)
        {
            var xmlContent = await GetXmlContent(url);
            var items = feedType switch
            {
                Atom => ParseXmlAtomFeed(xmlContent),
                Rss => ParseXmlRssFeed(xmlContent),
                _ => throw new IndexOutOfRangeException(nameof(feedType))
            };

            var posts = new ConcurrentBag<Post>();

            Parallel.ForEach(items, async item =>
            {
                var text = await GetMainTextAsync(item.Url);
                posts.Add(new Post(item.Title, text, item.PublishDate.Date, item.Id));
            });

            return posts;
        }

        private async Task<string> GetXmlContent(string feedUrl)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(feedUrl);
            return await response.Content.ReadAsStringAsync();
        }


        private IEnumerable<FeedItem> ParseXmlRssFeed(string xmlString)
        {
            var xDocument = XDocument.Parse(xmlString);

            if (xDocument.Root != null)
                return xDocument.Root
                    .Elements()
                    .First()
                    .Elements()
                    .Where(x => x.Name.LocalName == "item")
                    .Select(x => new RssFeedItem(x));

            throw new Exception(
                "Invalid feed format, or I did not properly parsed the xml, either way you are at your own.");
        }

        private IEnumerable<FeedItem> ParseXmlAtomFeed(string xmlString)
        {
            var xDocument = XDocument.Parse(xmlString);

            if (xDocument.Root != null)
                return xDocument.Root
                    .Elements()
                    .Where(x => x.Name.LocalName == "entry")
                    .Select(x => new AtomFeedItem(x));

            throw new Exception(
                "Invalid feed format, or I did not properly parsed the xml, either way you are at your own.");
        }
    }
}