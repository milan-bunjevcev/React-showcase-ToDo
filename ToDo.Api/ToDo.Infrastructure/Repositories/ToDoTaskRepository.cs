using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Infrastructure.Repositories;

public class ToDoTaskRepository : IToDoTaskRepository
{
    private readonly ToDoDbContext _dbContext;

    public ToDoTaskRepository(ToDoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ToDoTask entity)
    {
        await _dbContext.ToDoTasks.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<ToDoTask?> FindByIdAsync(Guid id)
    {
        return _dbContext.ToDoTasks.SingleOrDefaultAsync(task => task.Id == id);
    }

    public async Task RemoveAsync(ToDoTask entity)
    {
        _dbContext.ToDoTasks.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ToDoTask>> GetAllAsync()
    {
        var tasks = await _dbContext.ToDoTasks.ToListAsync();
        return tasks;
    }

    public async Task UpdateAync(ToDoTask updatedTask)
    {
        var existing = await FindByIdAsync(updatedTask.Id);
        if (existing is null)
        {
            throw new EntityNotFoundException();
        }

        existing.Name = updatedTask.Name;
        existing.IsCompleted = updatedTask.IsCompleted;

        await _dbContext.SaveChangesAsync();
    }
}
