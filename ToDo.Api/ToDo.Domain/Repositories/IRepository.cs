namespace ToDo.Domain.Repositories;

public interface IRepository<TEntity, TEntityId>
{
    Task AddAsync(TEntity entity);

    Task<TEntity?> FindByIdAsync(TEntityId id);

    Task RemoveAsync(TEntity entity);
}
