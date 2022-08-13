using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class LessonController : CustomBaseController
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByEducationId(int id)
        {
            return Ok(await _lessonService.GetByEducationIdAsync(id));
        }
    }
}
