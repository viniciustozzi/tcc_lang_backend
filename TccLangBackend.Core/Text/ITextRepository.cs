using System.Collections.Generic;
using System.Threading.Tasks;

namespace TccLangBackend.Core.Text
{
    public interface ITextRepository
    {
        IEnumerable<ModelText> GetAll(int userId);
        Task<ModelText> GetAsync(int userId, int textId);
        Task CreateAsync(CreateText createText);
    }
}