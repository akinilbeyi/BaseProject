using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
    {

        var status = await _userService.Register(userForRegister!);

        if (status == false)
            return BadRequest("Registration failed");

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserForLoginDto userForLogin)
    {
        var result = await _userService.Login(userForLogin);

        if (result == false)
            return BadRequest("Login failed");


        return Ok();
    }
}
