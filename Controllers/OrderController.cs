using System;
using System.Collections.Generic;
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
    public class OrdersController : ControllerBase
    {
       private readonly IOrderRepository repo;
        public OrdersController (IOrderRepository IOrderRepository)
        {
            this.repo = IOrderRepository;
        }
        [HttpPost("GetList")]
        public async Task<IActionResult> RequestOrders(DateRangeDTO dateRange){
            
            var userId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok()

        }

    }
}