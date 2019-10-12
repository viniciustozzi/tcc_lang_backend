namespace TccLangBackend.Core.Text
{
    public class CreateText
    {
        public CreateText(string words, string title)
        {
            Words = words;
            Title = title;
        }

        public string Words { get; }
        public string Title { get; }
    }
}