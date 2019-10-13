namespace TccLangBackend.Core.Text
{
    public class CreateText
    {
        public CreateText(string words, string title, string lang)
        {
            Words = words;
            Title = title;
            Lang = lang;
        }

        public string Words { get; }
        public string Title { get; }
        public string Lang { get; }
    }
}