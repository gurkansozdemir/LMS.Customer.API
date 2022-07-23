using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Classroom> _dbSet;
        public ClassroomRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<Classroom>();
        }
    }
}
