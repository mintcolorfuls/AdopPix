using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<bool> CreateAsync(T entity);
        bool UpdateAsync(T entity);
        bool DeleteByIdAsync(T id);
    }
}
