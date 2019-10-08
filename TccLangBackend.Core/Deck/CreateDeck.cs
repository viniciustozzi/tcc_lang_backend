namespace TccLangBackend.Core.Deck
{
    public class CreateDeck
    {
        public CreateDeck(int userId, string title, int? textId)
        {
            UserId = userId;
            Title = title;
            TextId = textId;
        }

        public int UserId { get; }
        public string Title { get; }
        public int? TextId { get; }
    }
}