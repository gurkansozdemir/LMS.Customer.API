using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.RegisterDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class RegisterController : CustomBaseController
    {
        private readonly IRegisterService _service;
        private readonly IMapper _mapper;
        public RegisterController(IRegisterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return Ok(await _service.GetAllWithAdvertAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(SetRegisterDto registerDto)
        {
            var register = _mapper.Map<Register>(registerDto);
            await _service.AddAsync(register);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> AcceptRegister(int id)
        {
            return Ok(await _service.AcceptRegisterAsync(id));
        }
    }
}
