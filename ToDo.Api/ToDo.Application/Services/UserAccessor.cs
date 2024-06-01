using Microsoft.AspNetCore.Http;
using ToDo.Domain.Services;

namespace ToDo.Application.Services;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
    }

    public Guid? CurrentUserId
    {
        get
        {
            string? value = _httpContextAccessor
                .HttpContext?
                .User?
                .Claims
                .FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (Guid.TryParse(value, out var userId))
            {
                return userId;
            }

            return null;
        }
    }
}