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
        private readonly IUserRepository _userRepository;
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ActivityService(IUnitOfWork unitOfWork, IGenericRepository<Activity> genericRepository, IMapper mapper, IActivityRepository repository, IUserRepository userRepository, IInspectionRepository inspectionRepository) : base(genericRepository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _userRepository = userRepository;
            _inspectionRepository = inspectionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAndCreateInspectionsAsync(ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            await _repository.AddAsync(activity);
            var students = await _userRepository.GetStudentsByClassroomIdAsync(activity.ClassroomId);
            List<Inspection> defautInspections = new List<Inspection>();
            foreach (var std in students)
            {
                defautInspections.Add(new Inspection()
                {
                    Activity = activity,
                    StudentId = std.Id
                });
            }
            await _inspectionRepository.AddRangeAsync(defautInspections);
            await _unitOfWork.CommitAsync();
        }

        public async Task<CustomResponseDto<List<ActivityDto>>> GetByClassroomIdAsync(int id)
        {
            var activities = await _repository.GetByClassroomIdAsync(id);
            var activityDtos = _mapper.Map<List<ActivityDto>>(activities);
            return CustomResponseDto<List<ActivityDto>>.Success(activityDtos);
        }
    }
}
