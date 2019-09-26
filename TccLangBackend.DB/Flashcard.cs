using System.ComponentModel.DataAnnotations;

namespace TccLangBackend.DB
{
    public class Flashcard

    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int DockerId { get; set; }

        public Deck Deck { get; set; }
    }
}