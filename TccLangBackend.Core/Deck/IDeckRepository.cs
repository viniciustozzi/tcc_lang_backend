using System.Threading.Tasks;

namespace TccLangBackend.Core.Deck
{
    public interface IDeckRepository
    {
        Task CreateAsync(CreateDeck createDeck);
    }
}