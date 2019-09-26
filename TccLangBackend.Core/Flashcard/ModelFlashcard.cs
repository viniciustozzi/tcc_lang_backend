namespace TccLangBackend.Core.Flashcard
{
    public class ModelFlashcard
    {
        public ModelFlashcard(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; }
        public string Title { get; }
    }
}