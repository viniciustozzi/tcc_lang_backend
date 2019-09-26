namespace TccLangBackend.Core.Deck
{
    public class ModelDeck
    {
        public int Id { get; }
        public string Name { get; }

        public ModelDeck(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}