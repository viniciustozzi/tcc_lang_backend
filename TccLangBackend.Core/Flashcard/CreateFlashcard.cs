namespace TccLangBackend.Core.Flashcard
{
    public class CreateFlashcard
    {
        public CreateFlashcard(int deckId, string title)
        {
            DeckId = deckId;
            Title = title;
        }

        public int DeckId { get; }
        public string Title { get; }
    }
}