namespace TccLangBackend.Core.Flashcard
{
    public class CreateFlashcard
    {
        public CreateFlashcard(int userId, int deckId,
            string originalWord, string translatedWord)
        {
            UserId = userId;
            DeckId = deckId;
            OriginalWord = originalWord;
            TranslatedWord = translatedWord;
        }

        public int UserId { get; }
        public int DeckId { get; }
        public string OriginalWord { get; }
        public string TranslatedWord { get; }
    }
}