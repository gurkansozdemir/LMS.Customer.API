using EDU.Core.DTOs;
using EDU.Core.DTOs.RegisterDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Services
{
    public interface IRegisterService:IService<Register>
    {
        Task<CustomResponseDto<List<GetRegisterDto>>> GetAllWithAdvertAsync();
        Task<CustomResponseDto<NoContentDto>> AcceptRegisterAsync(int id);
    }
}
