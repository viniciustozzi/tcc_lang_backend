using System;

namespace TccLangBackend.Framework.Feed
{
    public class Post
    {
        private readonly string _url;

        public Post(string title, string mainContent, DateTime postDate, string url)
        {
            _url = url;
            Title = title;
            MainContent = mainContent;
            PostDate = postDate;
        }

        public string Title { get; }
        public string MainContent { get; }
        public DateTime PostDate { get; }
    }
}