using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace tcc_lang_backend.DB
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