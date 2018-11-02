using System.Threading.Tasks;
using API_Tradingcenter.DTOs;
using API_Tradingcenter.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_Tradingcenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       private readonly IOrderRepository repo;
        public OrderController (IOrderRepository IOrderRepository)
        {
            this.repo = IOrderRepository;
        }
        [HttpPost("request")]
        public async Task<IActionResult> RequestOrders(RequestForOrdersDTO request){
            
            return StatusCode(500);
        }

    }
}