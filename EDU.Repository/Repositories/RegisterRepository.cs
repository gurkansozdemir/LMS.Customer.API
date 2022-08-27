using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class RegisterRepository : GenericRepository<Register>, IRegisterRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Register> _dbSet;

        public RegisterRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbSet = appDbContext.Set<Register>();
        }

        public Task<List<Register>> GetAllWithAdvertAsync()
        {
            return _dbSet.Where(x => !x.IsAccept && !x.IsDeleted).Include(x => x.Advert).ToListAsync();
        }
    }
}
