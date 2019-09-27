using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TccLangBackend.DB
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public IList<Deck> Decks { get; set; }

        public IList<Text> Texts { get; set; }
    }
}