using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TccLangBackend.Api.Business.Feed
{
    public class FeedBusiness
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private class FeedItem
        {
            public string Title { get; }
            public string Url { get; set; }
            public DateTime PublishDate { get; set; }

            public FeedItem(XElement entry)
            {
                Title = GetFirstByLocalName(entry, "title").Value;

                var stringDate = GetFirstByLocalName(entry, "published").Value;
                PublishDate = DateTime.Parse(stringDate);

                var xLink = GetFirstByLocalName(entry, "link");
                Url = xLink.Attributes("href").First().Value;
            }

            private XElement GetFirstByLocalName(XElement entry, string localName) =>
                entry
                    .Elements()
                    .First(x => x.Name.LocalName == localName);
        }

        public FeedBusiness(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Post>> RetriveAsync(string url)
        {
            var xmlContent = await GetXmlContent(url);
            var items = ParseXmlAtomFeed(xmlContent);

            var posts = new ConcurrentBag<Post>();

            Parallel.ForEach(items, async item =>
            {
                var tika = new Tika(item.Url);
                var text = await tika.GetMainTextAsync();
                posts.Add(new Post(item.Title, text, item.PublishDate.Date, item.Url));
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

            return xDocument.Root
                .Elements()
                .Where(x => x.Name.LocalName == "entry")
                .Select(x => new FeedItem(x));
        }
    }
}