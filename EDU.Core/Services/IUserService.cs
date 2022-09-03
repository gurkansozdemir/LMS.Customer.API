using EDU.Core.DTOs;
using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<CustomResponseDto<GetUserDto>> LoginAsync(LoginDto login);
        Task<CustomResponseDto<List<GetUserDto>>> GetStudentsByClassroomIdAsync(int id);
        Task<CustomResponseDto<GetUserDto>> GetTeacherByClassroomIdAsync(int id);
        Task<CustomResponseDto<List<GetUserDto>>> GetAllStudentAsync();
        Task<CustomResponseDto<List<GetUserDto>>> GetAllTeachersAsync();
        Task<CustomResponseDto<List<MenuItemDto>>> GetMenuItemsByRoleIdAsync(int id); 
    }
}
