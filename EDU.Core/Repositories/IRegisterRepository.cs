using EDU.Core.Entities;

namespace EDU.Core.Repositories
{
    public interface IRegisterRepository:IGenericRepository<Register>
    {
        Task<List<Register>> GetAllWithAdvertAsync();
    }
}
