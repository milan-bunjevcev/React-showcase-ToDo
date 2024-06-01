namespace ToDo.Domain.Services;

public interface IUserAccessor
{
    Guid? CurrentUserId { get; }
}
