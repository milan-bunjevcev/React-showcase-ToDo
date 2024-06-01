namespace ToDo.Application.Dtos;

public class RegisterDto
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string RepeatedPassword { get; init; }
}
