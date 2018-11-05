using System;
using System.Security.Claims;
using System.Threading.Tasks;
using API_Tradingcenter.DTOs;
using API_Tradingcenter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Tradingcenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
       private readonly IOrderRepository repo;
        public OrderController (IOrderRepository IOrderRepository)
        {
            this.repo = IOrderRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> RequestOrders(int id){
            
            var userId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if(userId == id){
                return StatusCode(200);
            }
            return Unauthorized();
            
        }

    }
}