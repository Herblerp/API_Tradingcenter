using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Tradingcenter.BitMEX_API;
using API_Tradingcenter.Database;
using API_Tradingcenter.Helpers;
using API_Tradingcenter.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tradingcenter.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext context;
        public OrderRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> SaveOrderList(IEnumerable<Order> orderList)
        {

            foreach (var order in orderList)
            {
                if (! await OrderExists(order))
                {
                    await this.context.Orders.AddAsync(order);
                    await this.context.SaveChangesAsync();
                }
            }

            return orderList;
        }

        public async Task<IEnumerable<Order>> GetOrderList(DateRange daterange, int id)
        {

            var orders = await context.Orders.Where(x => x.UserId == id).ToListAsync();
            var lOrders = orders.OrderByDescending(x => x.TimePlaced);

            return lOrders;
        }

        public async Task<bool> UpdateRefreshDateTime(int id)
        {

            var userToUpdate = await this.context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (userToUpdate == null)
            {
                return false;
            }

            userToUpdate.LastRefresh = DateTime.Now;
            this.context.Update(userToUpdate);
            await this.context.SaveChangesAsync();
            return true;
        }
        public async Task<bool>OrderExists(Order order){

             Order compare = await context.Orders.FirstOrDefaultAsync(x => x.OrderId == order.OrderId);
             if(compare == null){
                 return false;
             }
             return true;
        }
    }
}