namespace TccLangBackend.Core.Feed
{
    public class FeedSource
    {
        public FeedSource(string url, string lang)
        {
            Url = url;
            Lang = lang;
        }

        public string Url { get; }

        public string Lang { get; }
    }
}