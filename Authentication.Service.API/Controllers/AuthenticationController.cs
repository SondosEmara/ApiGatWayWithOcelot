using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Authentication.Service.API.Models;
using Authentication.Service.API.Services;
using System.Reflection.Emit;
using Authentication.Service.API.Dto;
using Authentication.Service.API.Seed;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentication.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
     
        public  ITokenService<User>? tokenService {  get; set; }
        public AuthenticationController(ITokenService<User>? _tokenService)
        {
            tokenService=_tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            var user = UserSeed.Users.FirstOrDefault(user => user.password == request.Password && user.username== request.Username);
            await Task.Delay(10);
            if (user == null)
            {
                return Unauthorized("Invalid credentials...!");
            }

            var token = tokenService?.GenerateToken(user);

            return Ok(new {Token = token });
        }
    }
}
