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
        private readonly IService<Inspection> _service;
        private readonly IMapper _mapper;
        public InspectionController(IService<Inspection> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddRange(List<SetInspectionDto> inspectionDtos)
        {
            var inspections = _mapper.Map<List<Inspection>>(inspectionDtos);
            await _service.AddRangeAsync(inspections);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
    }
}
