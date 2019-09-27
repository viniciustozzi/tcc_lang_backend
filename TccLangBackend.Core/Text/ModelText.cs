namespace TccLangBackend.Core.Text
{
    public class ModelText
    {
        public ModelText(int id, string title, string words)
        {
            Id = id;
            Title = title;
            Words = words;
        }

        public int Id { get; }
        public string Title { get; }
        public string Words { get; }
    }
}