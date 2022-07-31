using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        Task<List<Activity>> GetByClassroomIdAsync(int id);
    }
}
