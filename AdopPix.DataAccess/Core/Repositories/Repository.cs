using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext context;
        protected readonly ILogger logger;
        protected DbSet<T> dbSet;

        public Repository(ApplicationDbContext context, 
                          ILogger logger)
        {
            this.context = context;
            this.logger = logger;
            dbSet = context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual bool Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public virtual bool DeleteById(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }
    }
}
