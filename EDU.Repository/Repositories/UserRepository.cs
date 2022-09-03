using EDU.Core;
using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly DbSet<StudentOfClassroom> _studentOfClasses;
        private readonly DbSet<TeacherOfClassroom> _teacherOfClasses;
        private readonly DbSet<Role> _roleDbSet;
        public UserRepository(AppDbContext context) : base(context)
        {
            _users = context.Set<User>();
            _roleDbSet = context.Set<Role>();
            _studentOfClasses = context.Set<StudentOfClassroom>();
            _teacherOfClasses = context.Set<TeacherOfClassroom>();
        }

        public async Task<List<User>> GetAllStudentAsync()
        {
            return await _users.Where(x => x.RoleId == (int)RoleEnum.Student && !x.IsDeleted).ToListAsync();
        }

        public async Task<List<User>> GetAllTeachersAsync()
        {
            return await _users.Where(x => x.RoleId == (int)RoleEnum.Teacher && !x.IsDeleted).ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _roleDbSet.Where(x => !x.IsDeleted && x.Id == id).Include(x => x.MenuItems).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetStudentsByClassroomIdAsync(int id)
        {
            return await _studentOfClasses.Where(x => x.ClassroomId == id && x.IsActive).Select(x => x.Student).ToListAsync();
        }

        public async Task<User> GetTeacherByClassroomIdAsync(int id)
        {
            return await _teacherOfClasses.Where(x => x.ClassroomId == id && x.IsActive).Select(x => x.Teacher).FirstOrDefaultAsync();
        }

        public async Task<User> LoginAsync(LoginDto login)
        {
            return await _users.Where(x => x.EMail == login.EMail || x.UserName == login.EMail).Include(x => x.Role).SingleOrDefaultAsync();
        }
    }
}
