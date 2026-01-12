namespace HorizonteAzulApi.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entidade);
        Task Update(TEntity entidade);
        Task DeleteAsync(TEntity entidade);
        Task SaveChangesAsync();
    }
}
