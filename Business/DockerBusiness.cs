using TccLangBackend.Api.DB;
using TccLangBackend.DB;
using TccLangBaekend.DB;

namespace TccLangBackend.Api.Business
{
    public class DockerBusiness
    {
        private readonly TccDbContext _dbContext;

        public DockerBusiness(TccDbContext dbContext) => _dbContext = dbContext;
    }
}