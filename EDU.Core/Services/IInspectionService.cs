using EDU.Core.DTOs;
using EDU.Core.DTOs.InpectionDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Services
{
    public interface IInspectionService : IService<Inspection>
    {
        Task<CustomResponseDto<List<GetInspectionDto>>> GetByActivityIdAsync(int id);

        Task<CustomResponseDto<NoContentDto>> CreateAndUpdateAsync(List<SetInspectionDto> inspections);
    }
}
