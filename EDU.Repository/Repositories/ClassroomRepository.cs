using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        private readonly AppDbContext _contex;
        private readonly DbSet<Classroom> _dbSet;
        public ClassroomRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _contex = appDbContext;
            _dbSet = appDbContext.Set<Classroom>();
        }

        public async Task<List<Classroom>> GetAllWithEducationAsync()
        {
            return await _dbSet.Include(x => x.Education).ToListAsync();
        }
    }
}
