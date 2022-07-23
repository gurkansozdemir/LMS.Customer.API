using AutoMapper;
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithEducation()
        {
            return Ok(await _service.GetAllWithEducationAsync());
        }
    }
}
