namespace TccLangBackend.Core.Text
{
    public class SummaryText
    {
        public SummaryText(int id, string title, string words)
        {
            Id = id;
            Title = title;
            Words = words;
        }

        public int Id { get; }
        public string Title { get; }
        public string Words { get; }
    }
}