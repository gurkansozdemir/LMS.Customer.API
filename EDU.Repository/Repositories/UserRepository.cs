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
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _users = _context.Set<User>();
        }
        public async Task<User> LoginAsync(LoginDto login)
        {
            return await _users.Where(x => x.EMail == login.EMail || x.UserName == login.EMail).SingleOrDefaultAsync();
        }
    }
}
