using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
        Task<List<Classroom>> GetAllWithEducationAsync();
    }
}
