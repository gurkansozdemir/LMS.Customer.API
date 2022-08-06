using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Remove(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
    }
}
