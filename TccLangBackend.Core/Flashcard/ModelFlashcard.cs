namespace TccLangBackend.Core.Flashcard
{
    public class ModelFlashcard
    {
        public ModelFlashcard(int id, string originalWord, string translatedWord)
        {
            Id = id;
            OriginalWord = originalWord;
            TranslatedWord = translatedWord;
        }

        public int Id { get; }
        public string OriginalWord { get; }
        public string TranslatedWord { get; }
    }
}