/*
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BitMEX_API
{
    internal class Program
    {
        
        private static string bitmexKey = "FO_DwD6WrxiP2oz4dOr-sOlI";
        private static string bitmexSecret = "hOMcB0cin9hMqIMMCJbWAfcK8XkgNFKgBaU1Z6eNe2CAigg4";

        private static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            List<BitMEXOrder> orderlist = new List<BitMEXOrder>();
            orderlist = BitMEX.getAllOrders(bitmexKey,bitmexSecret);

            foreach (BitMEXOrder order in orderlist)
            {
                Console.WriteLine(order.currency);
            }
                        
            System.Threading.Thread.Sleep(500000);
         
        }
    }
}*/