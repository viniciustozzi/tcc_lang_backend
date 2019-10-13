using System;

namespace TccLangBackend.Core.Feed
{
    public class Post
    {
        public Post(string title, string mainContent, DateTime postDate, string id)
        {
            Title = title;
            MainContent = mainContent;
            PostDate = postDate;
            Id = id;
        }

        public string Id { get; }
        public string Title { get; }
        public string MainContent { get; }
        public DateTime PostDate { get; }
    }
}