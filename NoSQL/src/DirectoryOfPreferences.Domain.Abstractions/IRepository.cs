using DirectoryOfPreferences.Domain.Entity.Base;

namespace DirectoryOfPreferences.Domain.Abstractions
{
    public class IRepository<TEntity, TId> where TEntity : Entity<TId> where TId : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken token = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}