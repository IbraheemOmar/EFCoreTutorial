namespace EFCoreTutorial.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        void DeleteAll();
        Task DeleteAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}