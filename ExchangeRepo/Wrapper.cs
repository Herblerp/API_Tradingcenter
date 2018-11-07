using System.Collections.Generic;
using System;
using API_Tradingcenter.Models;

namespace API_Tradingcenter.BitMEX_API
{
    class Wrapper
    {
        public static List<Order> getAllOrders(string apiKey, string apiSecret, int id)
        {
            List<BitMEXOrder> BitMEXOrderList = new List<BitMEXOrder>();
            List<Order> OrderList = new List<Order>();
            BitMEXOrderList = BitMEX.getAllBitMEXOrders(apiKey, apiSecret);
            foreach(var bmOrder in BitMEXOrderList)
            {
                //Order needs a constructor
                //I'm assuming Quentin knows how to get UserID
                //I don't understand why User needs to be included in here, but I'm sure senpai Quentin has his reasons
                //Ignore ugly af Side code, if Side is Sell, it will return false (0); otherwise true
                Order order = new Order{
                    OrderId = bmOrder.orderID,
                    UserId = id,
                    Exchange = "BitMEX",
                    IsBuy = false, //Needs fix
                    Symbol = bmOrder.symbol.Substring(0,3),
                    Qty = (double)bmOrder.orderQty,
                    Currency = bmOrder.currency,
                    Price = (double)bmOrder.price,
                    TimePlaced = DateTime.Parse(bmOrder.timestamp)
                };
                OrderList.Add(order);
            }
            return OrderList;
        }
    }
}