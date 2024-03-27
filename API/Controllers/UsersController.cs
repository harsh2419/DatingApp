using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return Ok(await _userRepository.GetAllMembers());
    }

    [HttpGet("{username}")]
    [AllowAnonymous]

    public async Task<ActionResult<User>> GetUser(string username)
    {
        return Ok(await _userRepository.GetMember(username));
    }

    [HttpGet("getUserById/{id}")]
    [AllowAnonymous]

    public async Task<ActionResult<User>> GetUserById(int id)
    {
        return Ok(await _userRepository.GetUserById(id));
    }
}
