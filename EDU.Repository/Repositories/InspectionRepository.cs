using EDU.Core.DTOs.InpectionDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository.Repositories
{
    public class InspectionRepository : GenericRepository<Inspection>, IInspectionRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Inspection> _dbSet;
        public InspectionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<Inspection>();
        }

        public Task<List<Inspection>> GetByActivityIdAsync(int id)
        {
            return _dbSet.Where(x => !x.IsDeleted && x.ActivityId == id).Include(x => x.Student).ToListAsync();
        }
    }
}
