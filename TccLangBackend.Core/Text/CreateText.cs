namespace TccLangBackend.Core.Text
{
    public class CreateText
    {
        public CreateText(string words, int userId, string title)
        {
            Words = words;
            UserId = userId;
            Title = title;
        }

        public string Words { get; }
        public int UserId { get; }
        public string Title { get; }
    }
}