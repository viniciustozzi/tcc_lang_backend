using System.ComponentModel.DataAnnotations;

namespace TccLangBackend.Framework.DB
{
    public class Bookmark
    {
        [Key] public int Id { get; set; }
        public int UserId { get; set; }

        public int TextId { get; set; }

        public User User { get; set; }

        public Text Text { get; set; }
    }
}