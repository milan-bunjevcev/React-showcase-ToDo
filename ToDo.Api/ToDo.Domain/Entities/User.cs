namespace ToDo.Domain.Entities;

public class User
{
    public const int MaxUsernameLength = 50;
    public const int MaxPasswordLength = 100;

    public required Guid Id { get; init; }

    public required string Username { get; set; }

    public required string Password { get; set; }
}