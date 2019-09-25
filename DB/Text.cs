using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tcc_lang_backend.DB
{
    public class Text
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Words { get; set; }

        public IList<Deck> Decks { get; set; }
    }
}