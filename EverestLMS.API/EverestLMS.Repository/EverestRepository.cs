using EverestLMS.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository
{
    public class EverestRepository<TEntity> : IEverestRepository<TEntity> where TEntity : class
    {
        private readonly everestlmsContext context;

        public EverestRepository(everestlmsContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Update(entity);
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
