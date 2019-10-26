using System.Threading.Tasks;

namespace TccLangBackend.Core.User
{
    public interface IUserRepository
    {
        Task<bool> ExistAsync(int userId);
    }
}