using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TccLangBackend.Framework.DB
{
    public class Text
    {
        [Key] public int Id { get; set; }

        public string Title { get; set; }

        public string Words { get; set; }

        public ICollection<Deck> Decks { get; set; }
    }
}