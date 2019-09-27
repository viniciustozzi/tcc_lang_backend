using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Text
{
    public class TextBusiness
    {
        private readonly ITextRepository _textRepository;

        public TextBusiness(ITextRepository textRepository) => _textRepository = textRepository;

        public IEnumerable<ModelText> GetAll(int userId) => _textRepository.GetAll(userId);

        public Task<ModelText> GetAsync(int userId, int textId) => _textRepository.GetAsync(userId, textId);

        public Task CreateAsync(CreateText createText) => _textRepository.CreateAsync(createText);
    }
}