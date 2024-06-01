namespace ToDo.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string? message) : base(message)
    {
    }

    public EntityNotFoundException() : base("Entity could not be found")
    {
    }
}
