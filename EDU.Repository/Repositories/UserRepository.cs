using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<User> _users;
        private readonly DbSet<StudentOfClassroom> _studentOfClasses;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _users = context.Set<User>();
            _studentOfClasses = context.Set<StudentOfClassroom>();
        }

        public async Task<List<User>> GetStudentsByClassroomIdAsync(int id)
        {
            return await _studentOfClasses.Where(x => x.ClassroomId == id && x.IsActive == true).Select(x => x.Student).ToListAsync();
        }

        public async Task<User> LoginAsync(LoginDto login)
        {
            return await _users.Where(x => x.EMail == login.EMail || x.UserName == login.EMail).SingleOrDefaultAsync();
        }
    }
}
