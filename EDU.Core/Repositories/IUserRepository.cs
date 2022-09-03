using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginDto login);
        Task<List<User>> GetStudentsByClassroomIdAsync(int id);
        Task<User> GetTeacherByClassroomIdAsync(int id);
        Task<List<User>> GetAllStudentAsync();
        Task<List<User>> GetAllTeachersAsync();
        Task<Role> GetRoleByIdAsync(int id);

    }
}
