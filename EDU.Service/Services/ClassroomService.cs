using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.ClassroomDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;

namespace EDU.Service.Services
{
    public class ClassroomService : Service<Classroom>, IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;
        public ClassroomService(IGenericRepository<Classroom> repository, IUnitOfWork unitOfWork, IClassroomRepository classroomRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<GetClassroomDto>>> GetAllWithEducationAsync()
        {
            var classrooms = await _classroomRepository.GetAllWithEducationAsync();
            var classroomDtos = _mapper.Map<List<GetClassroomDto>>(classrooms);
            return CustomResponseDto<List<GetClassroomDto>>.Success(classroomDtos);
        }
    }
}
