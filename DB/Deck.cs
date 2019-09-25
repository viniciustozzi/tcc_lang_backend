using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tcc_lang_backend.DB
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public IList<Flashcard> Flashcards { get; set; }
        public int? TextId { get; set; }
        public Text Text { get; set; }
    }
}