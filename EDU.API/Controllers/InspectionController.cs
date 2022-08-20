using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.InpectionDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class InspectionController : CustomBaseController
    {
        private readonly IInspectionService _service;
        private readonly IMapper _mapper;
        public InspectionController(IInspectionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByActivityId(int id)
        {
            return Ok(await _service.GetByActivityIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRange(List<SetInspectionDto> inspectionDtos)
        {
            var inspections = _mapper.Map<List<Inspection>>(inspectionDtos);
            await _service.AddRangeAsync(inspections);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Save(List<SetInspectionDto> inspectionDtos)
        {
            return Ok(await _service.CreateAndUpdateAsync(inspectionDtos));
        }
    }
}
