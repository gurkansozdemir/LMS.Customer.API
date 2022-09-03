using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;

namespace EDU.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<User> genericRepository) : base(genericRepository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<GetUserDto>>> GetAllStudentAsync()
        {
            var users = await _repository.GetAllStudentAsync();
            var userDtos = _mapper.Map<List<GetUserDto>>(users);
            return CustomResponseDto<List<GetUserDto>>.Success(userDtos);
        }

        public async Task<CustomResponseDto<List<GetUserDto>>> GetAllTeachersAsync()
        {
            var users =await _repository.GetAllTeachersAsync();
            var userDtos= _mapper.Map<List<GetUserDto>>(users);
            return CustomResponseDto<List<GetUserDto>>.Success(userDtos);
        }

        public async Task<CustomResponseDto<List<MenuItemDto>>> GetMenuItemsByRoleIdAsync(int id)
        {
            var role = await _repository.GetRoleByIdAsync(id);
            var menuItemDtos = _mapper.Map<List<MenuItemDto>>(role.MenuItems);
            return CustomResponseDto<List<MenuItemDto>>.Success(menuItemDtos);
        }

        public async Task<CustomResponseDto<List<GetUserDto>>> GetStudentsByClassroomIdAsync(int id)
        {
            var users = await _repository.GetStudentsByClassroomIdAsync(id);
            var userDtos = _mapper.Map<List<GetUserDto>>(users);
            return CustomResponseDto<List<GetUserDto>>.Success(userDtos);
        }

        public async Task<CustomResponseDto<GetUserDto>> GetTeacherByClassroomIdAsync(int id)
        {
            var user = await _repository.GetTeacherByClassroomIdAsync(id);
            var userDto = _mapper.Map<GetUserDto>(user);
            return CustomResponseDto<GetUserDto>.Success(userDto);
        }

        public async Task<CustomResponseDto<GetUserDto>> LoginAsync(LoginDto login)
        {
            var user = await _repository.LoginAsync(login);
            var result = new CustomResponseDto<GetUserDto>();
            if (user != null)
            {
                if (user.Password == login.Password)
                {
                    var userDto = _mapper.Map<User, GetUserDto>(user);
                    userDto.Role = user.Role.Name;
                    result = CustomResponseDto<GetUserDto>.Success(userDto);
                }
                else
                {
                    result = CustomResponseDto<GetUserDto>.Fail(new List<string>() { "Wrong Password!" });
                }
            }
            else
            {
                result = CustomResponseDto<GetUserDto>.Fail(new List<string>() { "User Is Not Register!" });
            }
            return result;
        }


    }
}
