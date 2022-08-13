using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        private readonly DbSet<Lesson> _lessons;
        public LessonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _lessons = appDbContext.Set<Lesson>();
        }

        public async Task<List<Lesson>> GetByEducationIdAsync(int id)
        {
            return await _lessons.Where(x => !x.IsDeleted && x.EducationId == id).ToListAsync();
        }
    }
}
