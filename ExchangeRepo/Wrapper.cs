using System.Collections.Generic;
using System;

namespace API_Tradingcenter.BitMEX_API
{
    class Wrapper
    {
        public static List<Order> getAllOrders(string apiKey, string apiSecret)
        {
            List<BitMEXOrder> BitMEXOrderList = new List<BitMEXOrder>();
            List<Order> OrderList = new List<Order>();
            BitMEXOrderList = BitMEX.getAllBitMEXOrders(apiKey, apiSecret);

        }
    }
}