using AutoMapper;
using EDU.Core;
using EDU.Core.DTOs;
using EDU.Core.DTOs.RegisterDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;
using EDU.Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Service.Services
{
    public class RegisterService : Service<Register>, IRegisterService
    {
        private readonly IRegisterRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterService(IGenericRepository<Register> genericRepository, IUnitOfWork unitOfWork, IRegisterRepository registerRepository, IMapper mapper, IUserRepository userRepository) : base(genericRepository, unitOfWork)
        {
            _repository = registerRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<NoContentDto>> AcceptRegisterAsync(int id)
        {
            var register = await _repository.GetByIdAsync(id);
            User newUser = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                CreatedOn = DateTime.Now,
                EMail = register.EMail,
                Password = register.LastName + "123",
                UserName = register.EMail,
                RoleId = (int)RoleEnum.Student
            };
            await _userRepository.AddAsync(newUser);
            register.IsAccept = true;
            _repository.Update(register);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success();
        }

        public async Task<CustomResponseDto<List<GetRegisterDto>>> GetAllWithAdvertAsync()
        {
            var registers = await _repository.GetAllWithAdvertAsync();
            var registerDtos = _mapper.Map<List<GetRegisterDto>>(registers.ToList());
            return CustomResponseDto<List<GetRegisterDto>>.Success(registerDtos);
        }
    }
}
