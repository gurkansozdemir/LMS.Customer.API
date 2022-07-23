using AutoMapper;
using EDU.Core.DTOs.ClassroomDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class ClassroomController : CustomBaseController
    {
        private readonly IClassroomService _service;
        private readonly IService<StudentOfClassroom> _sofcService;
        private readonly IMapper _mapper;
        public ClassroomController(IClassroomService classroomService, IMapper mapper, IService<StudentOfClassroom> sofcService)
        {
            _service = classroomService;
            _mapper = mapper;
            _sofcService = sofcService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithEducation()
        {
            return Ok(await _service.GetAllWithEducationAsync());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IncludeStudent(IncludeStudentDto include)
        {
            var sofc = _mapper.Map<StudentOfClassroom>(include);
            await _sofcService.AddAsync(sofc);
            return Ok();
        }
    }
}
