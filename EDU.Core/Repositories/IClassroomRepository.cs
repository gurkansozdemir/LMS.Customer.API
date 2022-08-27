using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
        Task<List<Classroom>> GetAllWithEducationAsync();
        Task<Classroom> GetDetailByIdAsync(int id);
        Task<List<Classroom>> GetByTeacherIdAsync(int id);
    }
}
