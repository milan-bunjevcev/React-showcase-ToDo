using ToDo.Application.Dtos;
using ToDo.Application.Extensions;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;

namespace ToDo.Application.Services;

public class ToDoTaskService : IToDoTaskService
{
    private IToDoTaskRepository _taskRepository;
    private IUserAccessor _userAccessor;

    public ToDoTaskService(IToDoTaskRepository taskRepository, IUserAccessor userAccessor)
    {
        _taskRepository = taskRepository;
        _userAccessor = userAccessor;
    }

    public async Task<IEnumerable<ToDoTaskDto>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();

        return tasks.ToDto();
    }

    public async Task<ToDoTaskDto?> GetByIdAsync(Guid id)
    {
        var task = await _taskRepository.FindByIdAsync(id);

        return task?.ToDto();
    }

    public async Task<ToDoTaskDto> AddNewAsync(CreateToDoTaskDto request)
    {
        if (_userAccessor.CurrentUserId.GetValueOrDefault().Equals(Guid.Empty))
        {
            throw new AuthenticationException();
        }

        var newTask = new ToDoTask
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsCompleted = false,
            UserId = _userAccessor.CurrentUserId!.Value,
        };

        await _taskRepository.AddAsync(newTask);

        return newTask.ToDto();
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await _taskRepository.FindByIdAsync(id);
        if (task is null)
        {
            throw new EntityNotFoundException();
        }

        await _taskRepository.RemoveAsync(task);
    }

    public async Task<ToDoTaskDto> UpdateAsync(Guid id, EditToDoTaskDto request)
    {
        var task = await _taskRepository.FindByIdAsync(id);
        if (task is null)
        {
            throw new EntityNotFoundException();
        }

        var updatedTask = new ToDoTask
        {
            Id = task.Id,
            Name = request.Name,
            IsCompleted = request.IsCompleted,
            UserId = task.UserId,
        };

        await _taskRepository.UpdateAync(updatedTask);
        return updatedTask.ToDto();
    }
}
