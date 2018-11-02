using System;
using System.IdentityModel.Tokens.Jwt;
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
            try
            {
                userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

                if (await repo.UserExists(userToRegisterDTO.Username))
                {
                    //BadRequest
                    return StatusCode(400,"Username already exists");
                }
                else
                {
                    var userToCreate = new User
                    {
                        Username = userToRegisterDTO.Username
                    };

                    var createdUser = await repo.Register(userToCreate, userToRegisterDTO.Password);

                    //Created
                    return StatusCode(201);
                }
            }
            catch
            {
                return StatusCode(500, "Something went wrong while attempting to register, please try again in a few moments.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserToLoginDTO userToLoginDTO)
        {
            try
            {
                var userFromRepo = await repo.Login(userToLoginDTO.Username.ToLower(), userToLoginDTO.Password);

                if (userFromRepo == null)
                {
                    //Unauthorized
                    return StatusCode(401, "Bad login");
                }
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                    //More claims here
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.GetSection("Appsettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenhandler = new JwtSecurityTokenHandler();

                var token = tokenhandler.CreateToken(tokenDescriptor);

                //Ok
                return StatusCode(200, new { token = tokenhandler.WriteToken(token) });
            }
            catch
            {
                return StatusCode(500, "Something went wrong while attempting to log in, please try again in a few moments.");
            }


        }

    }
}