using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ToDoDbContext _dbContext;

    public UserRepository(ToDoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<User?> FindByIdAsync(Guid id)
    {
        return _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task RemoveAsync(User entity)
    {
        _dbContext.Users.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<User?> FindByUsernameAsync(string username)
    {
        return _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
    }
}
