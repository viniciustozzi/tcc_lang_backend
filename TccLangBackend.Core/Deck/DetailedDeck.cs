using System.Collections.Generic;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.Core.Deck
{
    public class DetailedDeck
    {
        public DetailedDeck(int id, string title, int? textId, IEnumerable<ModelFlashcard> flashcards)
        {
            Id = id;
            Title = title;
            TextId = textId;
            Flashcards = flashcards;
        }

        public int Id { get; }
        public string Title { get; }
        public int? TextId { get; }
        public IEnumerable<ModelFlashcard> Flashcards { get; }
    }
}