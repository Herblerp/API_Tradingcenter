using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API_Tradingcenter.BitMEX_API;
using API_Tradingcenter.Helpers;
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
       private readonly IAuthRepository authRepo;
        public OrdersController (IOrderRepository IOrderRepository, IAuthRepository IAuthRepository)
        {
            this.repo = IOrderRepository;
            this.authRepo = IAuthRepository;
        }

//      /api/orders/get
        [HttpPost("get")]
        public async Task<IActionResult> GetOrders(DateRange dateRange)
        {
            //Check if the date is not null
            if(dateRange.dateTo == DateTime.MinValue)
            {
                //Bad request
                return StatusCode(400, "Date can not be null");
            }

            var userId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            return Ok(await repo.GetOrderList(dateRange, userId));
        }

//      /api/orders/refresh
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshOrders(){
            
            var userId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await repo.UpdateRefreshDateTime(userId);
            var orderlist = Wrapper.getAllOrders("FO_DwD6WrxiP2oz4dOr-sOlI", "hOMcB0cin9hMqIMMCJbWAfcK8XkgNFKgBaU1Z6eNe2CAigg2", userId);
            await repo.SaveOrderList(orderlist);
            
            //?Decide which orders to fetch?
            //Get orders from exchanges
            //Put all fetched orders in list
            //Save new orders in database

            return Ok();

        }

    }
}