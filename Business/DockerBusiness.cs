using tcc_lang_backend.DB;

namespace tcc_lang_backend.Business
{
    public class DockerBusiness
    {
        private readonly TccDbContext _dbContext;

        public DockerBusiness(TccDbContext dbContext) => _dbContext = dbContext;
    }
}