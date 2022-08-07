using EDU.Core.DTOs;
using EDU.Core.DTOs.InpectionDTOs;
using EDU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Services
{
    public interface IInspectionService : IService<Inspection>
    {
        Task<CustomResponseDto<List<GetInspectionDto>>> GetByActivityIdAsync(int id);
    }
}
