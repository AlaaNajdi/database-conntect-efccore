using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController()
    {
        _userService = new UserService();
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsersService();
        return Ok(users);
    }

    [HttpGet("{userId}")]
    public IActionResult GetSingleUserById(string userId)
    {
        if (!Guid.TryParse(userId, out Guid userIdGuid))
        {
            return BadRequest("Invalid user ID Format");
        }

        var user = _userService.GetUserByIdService(userIdGuid);

        if (user == null)
        {
            return NotFound($"User with {userId} does not exist");
        }
        return Ok(user);
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUserById(string userId)
    {
        if (!Guid.TryParse(userId, out Guid userIdGuid))
        {
            return BadRequest("Invalid user ID Format");
        }

        bool result = _userService.DeleteUserByIdService(userIdGuid);

        if (!result)
        {
            return NotFound($"User with {userId} does not exist");
        }
        return NoContent();
    }


     [HttpPost]
    public IActionResult CreateUser(CreateUserDto newUser)
    {
           var user = _userService.CreateUserService(newUser);

        // bool result = _userService.DeleteUserByIdService(userIdGuid);

        if (user == null)
        {
            return NotFound($"User could not be created");
        }
        return Created("created user", user);
    }

}
