using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.ActivityDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;

namespace EDU.Service.Services
{
    public class ActivityService : Service<Activity>, IActivityService
    {
        private readonly IActivityRepository _repository;
        private readonly IMapper _mapper;
        public ActivityService(IUnitOfWork unitOfWork, IGenericRepository<Activity> genericRepository, IMapper mapper, IActivityRepository repository) : base(genericRepository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CustomResponseDto<List<ActivityDto>>> GetByClassroomIdAsync(int id)
        {
            var activities = await _repository.GetByClassroomIdAsync(id);
            var activityDtos = _mapper.Map<List<ActivityDto>>(activities);
            return CustomResponseDto<List<ActivityDto>>.Success(activityDtos);
        }
    }
}
