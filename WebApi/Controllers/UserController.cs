using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet(Name = "getusers")]
    public Task<List<User>> GetUsers([FromQuery] string name, [FromQuery] string phone)
    {
        return _userService.GetUsers(name, phone);
    }
}