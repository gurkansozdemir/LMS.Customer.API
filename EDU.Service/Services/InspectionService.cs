using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.InpectionDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Service.Services
{
    public class InspectionService : Service<Inspection>, IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public InspectionService(IInspectionRepository inspectionRepository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Inspection> genericRepository) : base(genericRepository, unitOfWork)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateAndUpdateAsync(List<SetInspectionDto> inspectionDtos)
        {
            foreach (var inspectionDto in inspectionDtos)
            {
                var currentInspection = await _inspectionRepository.GetByIdAsync(inspectionDto.Id);
                currentInspection.IsCome = inspectionDto.IsCome;
                _inspectionRepository.Update(currentInspection);
            }
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success();
        }

        public async Task<CustomResponseDto<List<GetInspectionDto>>> GetByActivityIdAsync(int id)
        {
            var inspections = await _inspectionRepository.GetByActivityIdAsync(id);
            var inspectionDtos = _mapper.Map<List<GetInspectionDto>>(inspections);
            return CustomResponseDto<List<GetInspectionDto>>.Success(inspectionDtos);
        }
    }
}
