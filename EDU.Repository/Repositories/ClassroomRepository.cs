using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        private readonly DbSet<Classroom> _dbSet;

        public ClassroomRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbSet = appDbContext.Set<Classroom>();
        }

        public async Task<List<Classroom>> GetAllWithEducationAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).Include(x => x.Education).ToListAsync();
        }

        public async Task<Classroom> GetDetailByIdAsync(int id)
        {
            return await _dbSet.Where(x => x.Id == id && !x.IsDeleted)
                     .Include(x => x.Students.Where(x => x.IsActive))
                     .Include(x => x.Teachers.Where(x => x.IsActive)).ThenInclude(x=>x.Teacher)
                     .Include(x=>x.Activities.Where(x=>!x.IsDeleted))
                     .Include(x=>x.Education).FirstOrDefaultAsync();
                     
                     
        }
    }
}
