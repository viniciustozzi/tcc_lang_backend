using System;
using System.ComponentModel.DataAnnotations;
using TccLangBackend.Core.Flashcard;

namespace TccLangBackend.Framework.DB
{
    public class FlashcardLog
    {
        [Key] public int Id { get; set; }

        public int FlashcardId { get; set; }

        public Difficulty Difficulty { get; set; }

        public DateTime CreationDateTime { get; set; }

        public Flashcard Flashcard { get; set; }
    }
}