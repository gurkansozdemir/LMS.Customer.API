using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.ClassroomDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class ClassroomController : CustomBaseController
    {
        private readonly IClassroomService _service;
        private readonly IMapper _mapper;
        public ClassroomController(IClassroomService classroomService, IMapper mapper)
        {
            _service = classroomService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var classrooms = await _service.GetAllAsync();
            var classroomDtos = _mapper.Map<List<Classroom>, List<GetClassroomDto>>(classrooms.ToList());
            return Ok(CustomResponseDto<List<GetClassroomDto>>.Success(classroomDtos));
        }
    }
}
