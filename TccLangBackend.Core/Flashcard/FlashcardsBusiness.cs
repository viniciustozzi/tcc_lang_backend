using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Flashcard
{
    public class FlashcardsBusiness
    {
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardsBusiness(IFlashcardRepository flashcardRepository)
        {
            _flashcardRepository = flashcardRepository;
        }

        public IEnumerable<ModelFlashcard> GetFlashcards(int userId, int deckId)
        {
            return _flashcardRepository.GetAll(userId, deckId);
        }

        public Task<ModelFlashcard> GetFlashcard(int userId, int deckId, int flashcardId)
        {
            return _flashcardRepository.FindAsync(userId, deckId, flashcardId);
        }

        public Task<ModelFlashcard> Create(CreateFlashcard createFlashcard)
        {
            return _flashcardRepository.CreateAsync(createFlashcard);
        }

        public async Task CreateLogAsync(CreateLog createLog)
        {
            var previousEf = await _flashcardRepository.GetEasinessFactorByIdAsync(createLog.FlashcardId);

            var ef = CalcEF(previousEf, createLog.Difficulty);

            await _flashcardRepository.UpdateFlashcardEfById(createLog.FlashcardId, ef);

            await _flashcardRepository.CreateLogAsync(createLog);
        }

        public Task DeleteByOriginalWord(int userId, int deckId, string originalWord)
        {
            return _flashcardRepository.DeleteByOriginalWordAsync(userId, deckId, originalWord);
        }

        public async Task<IEnumerable<ModelFlashcard>> GetFlashcardToday(int userId, int deckId)
        {
            var flashcards = _flashcardRepository.GetAll(userId, deckId);

            var oldList = new List<ModelFlashcard>();

            foreach (var flashcard in flashcards)
            {
                var modelFlashcardLog = await _flashcardRepository.GetLastLogAsync(flashcard.Id);

                if (modelFlashcardLog != null)
                {
                    var days = (DateTime.Now - modelFlashcardLog.DateTime).TotalDays;
                    var result = days * CalcEF(flashcard.EasinessFactor, modelFlashcardLog.Difficulty);

                    if (result > days)
                        oldList.Add(flashcard);
                }
                else
                    oldList.Add(flashcard);
            }

            return oldList;
        }

        private double CalcEF(double ef, Difficulty difficulty)
        {
            double newEf = 0;
            switch (difficulty)
            {
                case Difficulty.Easy:
                    newEf = ef + (ef * 0.15);
                    break;
                case Difficulty.Medium:
                    newEf = ef;
                    break;
                case Difficulty.Hard:
                    newEf = ef - (ef * 0.15);
                    break;
            }

            if (newEf < 1.3)
                newEf = 1.3;

            return newEf;
        }
    }
}