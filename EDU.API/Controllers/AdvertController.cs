using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.AdvertDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class AdvertController : CustomBaseController
    {
        private readonly IService<Advert> _service;
        private readonly IMapper _mapper;

        public AdvertController(IService<Advert> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var adverts = await _service.GetAllAsync();
            var advertDtos = _mapper.Map<List<GetAdvertDto>>(adverts.ToList());
            return Ok(CustomResponseDto<List<GetAdvertDto>>.Success(advertDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Add(SetAdvertDto setAdvert)
        {      
            var advert = _mapper.Map<Advert>(setAdvert);
            await _service.AddAsync(advert);
            return Ok(CustomResponseDto<List<NoContentDto>>.Success());
        }
    }
}
