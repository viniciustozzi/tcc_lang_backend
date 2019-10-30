namespace TccLangBackend.Core.Feed
{
    public class FeedSource
    {
        public FeedSource(string url, string lang, FeedType feedType)
        {
            Url = url;
            Lang = lang;
            FeedType = feedType;
        }

        public string Url { get; }

        public string Lang { get; }
        public FeedType FeedType { get; }
    }
}