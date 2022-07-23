using EDU.Core.DTOs;
using EDU.Core.DTOs.ClassroomDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Services
{
    public interface IClassroomService : IService<Classroom>
    {
        Task<CustomResponseDto<List<GetClassroomDto>>> GetAllWithEducationAsync();
    }
}
