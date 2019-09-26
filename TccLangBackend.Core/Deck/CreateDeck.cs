namespace TccLangBackend.Core.Deck
{
    public class CreateDeck
    {
        public CreateDeck(int userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public int UserId { get; }
        public string Name { get; }
    }
}