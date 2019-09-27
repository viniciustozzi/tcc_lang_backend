namespace TccLangBackend.Core.Deck
{
    public class ModelDeck
    {
        public ModelDeck(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}