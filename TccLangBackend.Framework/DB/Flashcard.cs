using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TccLangBackend.Framework.DB
{
    public class Flashcard

    {
        [Key] public int Id { get; set; }

        public string OriginalWord { get; set; }

        public string TranslatedWord { get; set; }

        public int DeckId { get; set; }

        public Deck Deck { get; set; }

        public ICollection<FlashcardLog> FlashcardLogs { get; set; }
        
        public double EasinessFactor { get; set; }
    }
}