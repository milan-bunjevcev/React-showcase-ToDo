namespace ToDo.Application.Dtos;

public class ToDoTaskDto
{
    public required Guid Id { get; init; }

    public required string Name { get; set; }

    public required bool IsCompleted { get; set; }
}
