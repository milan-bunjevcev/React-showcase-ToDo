namespace ToDo.Application.Dtos;

public class EditToDoTaskDto
{
    public required string Name { get; set; }

    public required bool IsCompleted { get; set; }
}
