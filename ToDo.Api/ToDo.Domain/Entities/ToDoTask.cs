namespace ToDo.Domain.Entities;

public class ToDoTask : IUserBelongingEntity
{
    public const int MaxNameLength = 50;

    public required Guid Id { get; init; }

    public required string Name { get; set; }

    public required bool IsCompleted { get; set; }

    public required Guid UserId { get; init; }
}