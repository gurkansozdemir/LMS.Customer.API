using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginDto login);
    }
}
