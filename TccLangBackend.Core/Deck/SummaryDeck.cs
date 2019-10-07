namespace TccLangBackend.Core.Deck
{
    public class SummaryDeck
    {
        public SummaryDeck(int id, string title, int? textId)
        {
            Id = id;
            Title = title;
            TextId = textId;
        }

        public int Id { get; }
        public string Title { get; }
        public int? TextId { get; }
    }
}