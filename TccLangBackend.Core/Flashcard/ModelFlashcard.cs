namespace TccLangBackend.Core.Flashcard
{
    public class ModelFlashcard
    {
        public ModelFlashcard(int id, string originalWord, string translatedWord, double easinessFactor)
        {
            Id = id;
            OriginalWord = originalWord;
            TranslatedWord = translatedWord;
            EasinessFactor = easinessFactor;
        }

        public int Id { get; }
        public string OriginalWord { get; }
        public string TranslatedWord { get; }
        public double EasinessFactor { get; }
    }
}