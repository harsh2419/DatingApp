using System.Security.Cryptography;
using System.Text;
using API.Controllers;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountController : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
    {
        if (await UserExists(registerDTO.Username)) return BadRequest("User already exists!");

        using var hmac = new HMACSHA512();

        var user = new User
        {
            UserName = registerDTO.Username.ToLower(),
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
            passwordSalt = hmac.Key
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDTO
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
    {
        User user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.Username.ToLower());

        if (user == null) return Unauthorized("Invalid Username!");

        using var hmac = new HMACSHA512(user.passwordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.passwordHash[i]) return Unauthorized("Incorrect Password!");
        }

        return new UserDTO
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }
    private async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
}
