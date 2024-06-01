using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> FindByUsernameAsync(string username);
}
