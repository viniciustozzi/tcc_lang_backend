using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TccLangBackend.DB
{
    public class Text
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Words { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public IList<Deck> Decks { get; set; }
    }
}