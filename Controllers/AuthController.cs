using System.Security.Claims;
using System.Threading.Tasks;
using API_Tradingcenter.Data;
using API_Tradingcenter.DTOs;
using API_Tradingcenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API_Tradingcenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration config;
        private readonly IAuthRepository repo;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserToRegisterDTO userToRegisterDTO)
        {
            userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

            if (await repo.UserExists(userToRegisterDTO.Username))
            {
                return BadRequest("Username already exists");
            }
            else
            {
                var userToCreate = new User
                {
                    Username = userToRegisterDTO.Username
                };

                var createdUser = await repo.Register(userToCreate, userToRegisterDTO.Password);

                return StatusCode(201);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserToLoginDTO userToLoginDTO)
        {
            var userFromRepo = await repo.Login(userToLoginDTO.Username.ToLower(), userToLoginDTO.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.GetSection("Apsettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


        }

    }
}