using ToDo.Application.Dtos;

namespace ToDo.Application.Services;

public interface IUserService
{
    Task<AccessTokenDto> GetAccessTokenAsync(LoginDto loginDto);

    Task<AccessTokenDto> AddUserAsync(RegisterDto registerDto);
}
