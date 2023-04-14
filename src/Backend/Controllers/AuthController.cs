using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("auth/")]
public class AuthController : Controller
{
    private readonly JwtService _jwtService;
    private readonly UserManager<User> _userManager;
    public AuthController(
        UserManager<User> userManager,
        JwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }
    [HttpPost("login")]
    public Task<IActionResult> Login()
    {
        throw new NotImplementedException();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody]Register register)
    {
        var userIsExist = _userManager.Users.FirstOrDefault(t => t.Email == register.Email);

        if (userIsExist == null)
        {
            var user = new User
            {
                FirstName = register.FirstName,
                Email = register.Email,
                Id = Guid.NewGuid().ToString(),
                UserName = register.Username,
                LastName = register.LastName

            };
            var result = await _userManager.CreateAsync(user,
                register.Password);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    Message = "This is your token",
                    Token = _jwtService.GenerateToken(user)
                });
            }
            return BadRequest(result.Errors.ToString());
        }

        return BadRequest("the currently mail was actually used.");
    }
}