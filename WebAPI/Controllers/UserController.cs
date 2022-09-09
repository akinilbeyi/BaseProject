using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("Users")]
    public async Task<IActionResult> GetUsers()
    {
      var result = await _userService.GetAll();
        return Ok(result);
    }
    [HttpPost("Users")]
    public async Task<IActionResult> AddUser([FromBody]UserDto user)
    {
        var result = await _userService.Add(user);
        return Ok(result);
    }
    [HttpPut("Users")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
    {
        var result = await _userService.Update(user);
        return Ok(result);
    }

    [HttpGet("Users/{id}")]
    public async Task<IActionResult> GetUserById([FromRoute]int id)
    {
        var result = await _userService.GetById(id);
        return Ok(result);
    }
    [HttpDelete("Users/{id}")]
    public async Task<IActionResult> DeleteUserById([FromRoute] int id)
    {
        var result = await _userService.DeleteById(id);
        return Ok(result);
    }
}
