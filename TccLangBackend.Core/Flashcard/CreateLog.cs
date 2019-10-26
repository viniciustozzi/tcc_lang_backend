using System;

namespace TccLangBackend.Core.Flashcard
{
    public class CreateLog
    {
        public int FlashcardId { get; }
        public Difficulty Difficulty { get; }
        public DateTime CreationDateTime { get; }

        public CreateLog(int flashcardId, Difficulty difficulty, DateTime creationDateTime)
        {
            FlashcardId = flashcardId;
            Difficulty = difficulty;
            CreationDateTime = creationDateTime;
        }
    }
}