using System.Text;
using ToDo.Application.Dtos;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _secretKey = configuration.GetValue<string>("SecretKey")!;
        _issuer = configuration.GetValue<string>("TokenIssuer")!;
        _audience = configuration.GetValue<string>("TokenAudience")!;

        _userRepository = userRepository;
    }

    public async Task<AccessTokenDto> GetAccessTokenAsync(LoginDto loginDto)
    {
        var user = await _userRepository.FindByUsernameAsync(loginDto.Username);
        if (user is null)
        {
            throw new AuthenticationException();
        }

        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
        {
            throw new AuthenticationException();
        }

        var secretKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var signinCredentials =
            new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var options = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: new List<Claim>{new ("UserId", user.Id.ToString())},
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signinCredentials
        );

        return new AccessTokenDto
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(options)
        };
    }

    public async Task<AccessTokenDto> AddUserAsync(RegisterDto registerDto)
    {
        if (!registerDto.Password.Equals(registerDto.RepeatedPassword))
        {
            throw new AuthenticationException();
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = registerDto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
        };

        await _userRepository.AddAsync(user);

        return await GetAccessTokenAsync(new LoginDto
        {
            Username = registerDto.Username,
            Password = registerDto.Password
        });
    }
}
