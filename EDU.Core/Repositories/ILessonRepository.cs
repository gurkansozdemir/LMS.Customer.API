using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        Task<List<Lesson>> GetByEducationIdAsync(int id);
    }
}
