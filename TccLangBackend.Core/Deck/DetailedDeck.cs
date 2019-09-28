using System.Collections.Generic;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.Core.Deck
{
    public class DetailedDeck
    {
        public DetailedDeck(int id, string name, int? textId, IEnumerable<ModelFlashcard> flashcards)
        {
            Id = id;
            Name = name;
            TextId = textId;
            Flashcards = flashcards;
        }

        public int Id { get; }
        public string Name { get; }
        public int? TextId { get; }
        public IEnumerable<ModelFlashcard> Flashcards { get; }
    }
}