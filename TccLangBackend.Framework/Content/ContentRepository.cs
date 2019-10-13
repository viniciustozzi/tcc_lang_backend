using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using TccLangBackend.Core.Feed;
using static TccLangBackend.Framework.Content.Tika;

namespace TccLangBackend.Framework.Content
{
    public class ContentRepository : IContentRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContentRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Post>> RetrieveAsync(string url)
        {
            var xmlContent = await GetXmlContent(url);
            var items = ParseXmlAtomFeed(xmlContent);

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

        private IEnumerable<FeedItem> ParseXmlAtomFeed(string xmlString)
        {
            var xDocument = XDocument.Parse(xmlString);

            if (xDocument.Root != null)
                return xDocument.Root
                    .Elements()
                    .Where(x => x.Name.LocalName == "entry")
                    .Select(x => new FeedItem(x));

            throw new Exception(
                "Invalid feed format, or I did not properly parsed the xml, either way you are at your own.");
        }

        private class FeedItem
        {
            public FeedItem(XElement entry)
            {
                Id = GetFirstByLocalName(entry, "id").Value;

                Title = GetFirstByLocalName(entry, "title").Value;

                var stringDate = GetFirstByLocalName(entry, "published").Value;
                PublishDate = DateTime.Parse(stringDate);

                var xLink = GetFirstByLocalName(entry, "link");
                Url = xLink.Attributes("href").First().Value;
            }

            public string Id { get; }
            public string Title { get; }
            public string Url { get; }
            public DateTime PublishDate { get; }

            private static XElement GetFirstByLocalName(XElement entry, string localName)
            {
                return entry
                    .Elements()
                    .First(x => x.Name.LocalName == localName);
            }
        }
    }
}