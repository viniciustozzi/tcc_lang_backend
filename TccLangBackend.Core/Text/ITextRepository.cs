using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Text
{
    public interface ITextRepository
    {
        IEnumerable<SummaryText> GetAll(int userId);
        Task<DetailedText> GetAsync(int userId, int textId);
        Task CreateAsync(CreateText createText);
    }
}