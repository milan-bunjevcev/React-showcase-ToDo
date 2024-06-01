using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Extensions;

public static class ToDoTaskExtensions
{
    public static ToDoTaskDto ToDto(this ToDoTask entity)
        => new ToDoTaskDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsCompleted = entity.IsCompleted,
        };


    public static IEnumerable<ToDoTaskDto> ToDto(this IEnumerable<ToDoTask> entities)
        => entities.Select(ToDto);
}