using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;

namespace EDU.Service.Services
{
    public class ClassroomService : Service<Classroom>, IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        public ClassroomService(IGenericRepository<Classroom> repository, IUnitOfWork unitOfWork, IClassroomRepository classroomRepository) : base(repository, unitOfWork)
        {
            _classroomRepository = classroomRepository;
        }
    }
}
