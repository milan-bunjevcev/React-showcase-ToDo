using ToDo.Application.Dtos;

namespace ToDo.Application.Services;

public interface IToDoTaskService
{
    Task<IEnumerable<ToDoTaskDto>> GetAllAsync();

    Task<ToDoTaskDto?> GetByIdAsync(Guid id);
    
    Task<ToDoTaskDto> AddNewAsync(CreateToDoTaskDto request);

    Task DeleteAsync(Guid id);
    Task<ToDoTaskDto> UpdateAsync(Guid id, EditToDoTaskDto request);
}
