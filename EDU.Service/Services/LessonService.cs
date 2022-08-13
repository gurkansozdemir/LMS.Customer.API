using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.LessonDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;

namespace EDU.Service.Services
{
    public class LessonService : Service<Lesson>, ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        public LessonService(IGenericRepository<Lesson> repository, IUnitOfWork unitOfWork, ILessonRepository lessonRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<GetLessonDto>>> GetByEducationIdAsync(int id)
        {
            var lessons = await _lessonRepository.GetByEducationIdAsync(id);
            var lessonDtos = _mapper.Map<List<GetLessonDto>>(lessons);
            return CustomResponseDto<List<GetLessonDto>>.Success(lessonDtos);
        }
    }
}
