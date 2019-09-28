namespace TccLangBackend.Core.Deck
{
    public class CreateDeck
    {
        public CreateDeck(int userId, string name, int? textId)
        {
            UserId = userId;
            Name = name;
            TextId = textId;
        }

        public int UserId { get; }
        public string Name { get; }
        public int? TextId { get; }
    }
}