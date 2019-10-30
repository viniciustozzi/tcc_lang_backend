using System;
using System.Linq;
using System.Xml.Linq;

namespace TccLangBackend.Framework.Content
{
    internal class AtomFeedItem : FeedItem
    {
        public AtomFeedItem(XElement entry)
        {
            Id = GetFirstByLocalName(entry, "id").Value;

            Title = GetFirstByLocalName(entry, "title").Value;

            var stringDate = GetFirstByLocalName(entry, "published").Value;
            PublishDate = DateTime.Parse(stringDate);

            var xLink = GetFirstByLocalName(entry, "link");
            Url = xLink.Attributes("href").First().Value;
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