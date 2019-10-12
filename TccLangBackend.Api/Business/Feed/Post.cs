using System;

namespace TccLangBackend.Api.Business.Feed
{
    public class Post
    {
        private readonly string _url;
        public string Title { get; }
        public string MainContent { get; }
        public DateTime PostDate { get; }

        public Post(string title, string mainContent, DateTime postDate, string url)
        {
            _url = url;
            Title = title;
            MainContent = mainContent;
            PostDate = postDate;
        }
    }
}