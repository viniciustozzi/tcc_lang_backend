using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Text
{
    public class TextBusiness
    {
        private readonly ITextRepository _textRepository;

        public TextBusiness(ITextRepository textRepository) => _textRepository = textRepository;

        public IEnumerable<SummaryText> GetAll(int userId) => _textRepository.GetAll(userId);

        public Task<DetailedText> GetAsync(int userId, int textId) => _textRepository.GetAsync(userId, textId);

        public Task CreateAsync(CreateText createText) => _textRepository.CreateAsync(createText);
    }
}