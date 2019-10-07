using System.ComponentModel.DataAnnotations;

namespace TccLangBackend.DB
{
    public class Flashcard

    {
        [Key] public int Id { get; set; }

        public string OriginalWord { get; set; }

        public string TranslatedWord { get; set; }

        public int DeckId { get; set; }

        public Deck Deck { get; set; }
    }
}