using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IToDoTaskRepository : IRepository<ToDoTask, Guid>
{
    Task<IEnumerable<ToDoTask>> GetAllAsync();
    
    Task UpdateAync(ToDoTask updatedTask);
}
