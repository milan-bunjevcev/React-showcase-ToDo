using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos;
using ToDo.Application.Services;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AccessTokenDto>> RegisterAsync([FromBody] RegisterDto registerDto)
    {
        var token = await _userService.AddUserAsync(registerDto);

        return Ok(token);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AccessTokenDto>> LoginAsync([FromBody] LoginDto loginDto)
    {
        var token = await _userService.GetAccessTokenAsync(loginDto);

        return Ok(token);
    }
}