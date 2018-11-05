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
        [HttpPost("GetOrders")]
        public async Task<IActionResult> GetOrders(DateRangeDTO dateRange){

            //Datetime can not be null
            if(dateRange.dateTo == DateTime.MinValue){
                //Bad request
                return StatusCode(400, "dateTo value can not be null");
            }

            var userId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await repo.GetOrders(dateRange, userId));


        }
        [HttpPost("RefreshOrders")]
        public async Task<IActionResult> RefreshOrders(){
            
            var userId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            //Repo methodes hier

            return Ok();

        }

    }
}