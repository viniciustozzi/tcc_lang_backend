using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccLangBackend.Core.User;

namespace TccLangBackend.Framework.DB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TccDbContext _tccDbContext;

        public UserRepository(TccDbContext tccDbContext)
        {
            _tccDbContext = tccDbContext;
        }

        public Task<bool> ExistAsync(int userId)
        {
            return _tccDbContext.Users.AnyAsync(x => x.Id == userId);
        }
    }
}