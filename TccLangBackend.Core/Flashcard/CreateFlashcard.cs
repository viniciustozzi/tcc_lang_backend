namespace TccLangBackend.Core.Flashcard
{
    public class CreateFlashcard
    {
        public CreateFlashcard(int userId, int deckId, string title)
        {
            UserId = userId;
            DeckId = deckId;
            Title = title;
        }

        public int UserId { get; }
        public int DeckId { get; }
        public string Title { get; }
    }
}