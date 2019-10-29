using System;
using System.Linq;
using System.Xml.Linq;

namespace TccLangBackend.Framework.Content
{
    internal class RssFeedItem : FeedItem
    {
        public RssFeedItem(XElement entry)
        {
            Id = GetFirstByLocalName(entry, "guid").Value;

            Title = GetFirstByLocalName(entry, "title").Value;

            var stringDate = GetFirstByLocalName(entry, "pubDate").Value;
            PublishDate = DateTime.Parse(stringDate);

            Url = GetFirstByLocalName(entry, "link").Value;
        }

        public override string Id { get; }
        public override string Title { get; }
        public override string Url { get; }
        public override DateTime PublishDate { get; }

        private static XElement GetFirstByLocalName(XElement entry, string localName)
        {
            return entry
                .Elements()
                .First(x => x.Name.LocalName == localName);
        }
    }
}