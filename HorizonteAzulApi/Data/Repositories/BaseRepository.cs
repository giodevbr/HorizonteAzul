using HorizonteAzulApi.Data.Interfaces;
using HorizonteAzulApi.Data.Models.HorizonteAzul;

namespace HorizonteAzulApi.Data.Repositories
{
    public class BaseRepository<TEntity>(HorizonteAzulContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        protected HorizonteAzulContext _dbContext = context;

        public async Task AddAsync(TEntity entidade)
        {
            await _dbContext.Set<TEntity>().AddAsync(entidade);
        }

        public async Task Update(TEntity entidade)
        {
            _dbContext.Set<TEntity>().Update(entidade);
        }

        public async Task DeleteAsync(TEntity entidade)
        {
            _dbContext.Set<TEntity>().Remove(entidade);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
