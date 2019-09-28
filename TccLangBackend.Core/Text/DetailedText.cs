using TccLangBackend.Core.Deck;

namespace TccLangBackend.Core.Text
{
    public class DetailedText
    {
        public DetailedText(int id, string title, string words, DetailedDeck deck)
        {
            Id = id;
            Title = title;
            Words = words;
            Deck = deck;
        }

        public int Id { get; }
        public string Title { get; }
        public string Words { get; }
        public DetailedDeck Deck { get; }
    }
}