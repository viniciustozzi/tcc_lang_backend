namespace TccLangBackend.Core.Deck
{
    public class SummaryDeck
    {
        public SummaryDeck(int id, string name, int? textId)
        {
            Id = id;
            Name = name;
            TextId = textId;
        }

        public int Id { get; }
        public string Name { get; }
        public int? TextId { get; }
    }
}