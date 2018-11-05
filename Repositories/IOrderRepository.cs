using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Tradingcenter.Helpers;
using API_Tradingcenter.Models;

namespace API_Tradingcenter.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> SaveOrderList(IEnumerable<Order> orderList);
        Task<IEnumerable<Order>> GetOrderList(DateRange daterange, int id);
        Task<bool> UpdateRefreshDateTime(int id);
    }
}