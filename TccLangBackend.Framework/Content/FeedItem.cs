using System;

namespace TccLangBackend.Framework.Content
{
    public abstract class FeedItem
    {
        public abstract string Id { get; }
        public abstract string Title { get; }
        public abstract string Url { get; }
        public abstract DateTime PublishDate { get; }
    }
}