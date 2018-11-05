using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Tradingcenter.Database;
using API_Tradingcenter.DTOs;
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
        public async Task<Order> SaveOrder(Order order){
            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders(DateRangeDTO daterange, int id){
            
            var orders = await context.Orders.Where(x => (x.TimePlaced > daterange.dateFrom && x.TimePlaced < daterange.dateTo)&& x.UserId == id).ToListAsync();
            var lOrders = orders.OrderByDescending(x => x.TimePlaced);
            return lOrders;
        }
    }
}