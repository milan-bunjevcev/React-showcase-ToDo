namespace ToDo.Domain.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException(string? message) : base(message)
    {
    }

    public AuthenticationException() : base("Error while authenticating user")
    {
    }
}
