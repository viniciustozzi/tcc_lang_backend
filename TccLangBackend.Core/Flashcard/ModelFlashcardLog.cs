using System;

namespace TccLangBackend.Core.Flashcard
{
    public class ModelFlashcardLog
    {
        public int Id { get; set; }
        public int FlashcardId { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime DateTime { get; set; }
    }
}