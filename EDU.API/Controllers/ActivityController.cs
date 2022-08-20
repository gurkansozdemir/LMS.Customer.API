using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.ActivityDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class ActivityController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByClassroomId(int id)
        {
            return Ok(await _activityService.GetByClassroomIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityDto activityDto)
        {
            await _activityService.AddAndCreateInspectionsAsync(activityDto);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
    }
}
