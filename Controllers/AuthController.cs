using System.Threading.Tasks;
using API_Tradingcenter.Data;
using API_Tradingcenter.DTOs;
using API_Tradingcenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Tradingcenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        public AuthController(IAuthRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserToRegisterDTO userToRegisterDTO)
        {
            //Validate request

            userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

            if(await repo.UserExists(userToRegisterDTO.Username))
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

    }
}