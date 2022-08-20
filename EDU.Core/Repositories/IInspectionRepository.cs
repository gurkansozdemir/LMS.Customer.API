using EDU.Core.DTOs.InpectionDTOs;
using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface IInspectionRepository : IGenericRepository<Inspection>
    {
        Task<List<Inspection>> GetByActivityIdAsync(int id);
    }
}
