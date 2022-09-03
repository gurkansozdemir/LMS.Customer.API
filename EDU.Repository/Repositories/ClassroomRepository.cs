using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        private readonly DbSet<Classroom> _dbSet;
        private readonly DbSet<TeacherOfClassroom> _teacherOfClassroomDbSet;

        public ClassroomRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbSet = appDbContext.Set<Classroom>();
            _teacherOfClassroomDbSet = appDbContext.Set<TeacherOfClassroom>();
        }

        public async Task<List<Classroom>> GetAllWithEducationAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).Include(x => x.Education).ToListAsync();
        }

        public async Task<List<Classroom>> GetByTeacherIdAsync(int id)
        {
            return await _teacherOfClassroomDbSet.Where(x => x.TeacherId == id)
                     .Include(x => x.Classroom).ThenInclude(x => x.Teachers.Where(x => x.IsActive)).ThenInclude(x => x.Teacher)
                     .Include(x => x.Classroom).ThenInclude(x => x.Students.Where(x => x.IsActive))
                     .Include(x => x.Classroom).ThenInclude(x => x.Activities.Where(x => !x.IsDeleted))
                     .Include(x => x.Classroom).ThenInclude(x => x.Education)
                     .Select(x => x.Classroom).ToListAsync();
        }

        public async Task<Classroom> GetDetailByIdAsync(int id)
        {
            return await _dbSet.Where(x => x.Id == id && !x.IsDeleted)
                     .Include(x => x.Students.Where(x => x.IsActive))
                     .Include(x => x.Teachers.Where(x => x.IsActive)).ThenInclude(x => x.Teacher)
                     .Include(x => x.Activities.Where(x => !x.IsDeleted))
                     .Include(x => x.Education).FirstOrDefaultAsync();
        }
    }
}
