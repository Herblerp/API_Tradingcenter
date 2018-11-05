using System.Collections.Generic;
using System.Threading.Tasks;
using API_Tradingcenter.DTOs;
using API_Tradingcenter.Models;

namespace API_Tradingcenter.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> SaveOrder(Order order);
        Task<IEnumerable<Order>> GetOrders(DateRangeDTO daterange);
    }
}