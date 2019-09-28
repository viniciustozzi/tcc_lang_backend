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

        public int? DeckId { get; set; }

        public User User { get; set; }

        public Deck Deck { get; set; }
    }
}