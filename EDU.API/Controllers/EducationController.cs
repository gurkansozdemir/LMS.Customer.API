using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.EducationDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class EducationController : CustomBaseController
    {
        private readonly IService<Education> _service;
        private readonly IMapper _mapper;

        public EducationController(IService<Education> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var educations = await _service.GetAllAsync();
            var educationDtos = _mapper.Map<List<GetEducationDto>>(educations.ToList());
            return Ok(CustomResponseDto<List<GetEducationDto>>.Success(educationDtos));
        }
    }
}
