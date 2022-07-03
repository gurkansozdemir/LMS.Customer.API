using EDU.Core.DTOs;
using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<CustomResponseDto<GetUserDto>> LoginAsync(LoginDto login);
    }
}
