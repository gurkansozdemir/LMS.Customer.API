using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        private readonly DbSet<Activity> _activities;
        public ActivityRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _activities = appDbContext.Set<Activity>();
        }

        public async Task<List<Activity>> GetByClassroomIdAsync(int id)
        {
            return await _activities.Where(x => x.ClassroomId == id && !x.IsDeleted).ToListAsync();
        }
    }
}
