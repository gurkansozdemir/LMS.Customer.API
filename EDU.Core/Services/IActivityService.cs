using EDU.Core.DTOs;
using EDU.Core.DTOs.ActivityDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Services
{
    public interface IActivityService : IService<Activity>
    {
        Task<CustomResponseDto<List<ActivityDto>>> GetByClassroomIdAsync(int id);
        Task AddAndCreateInspectionsAsync(ActivityDto activityDto);
    }
}
