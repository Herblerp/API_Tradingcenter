using System;

namespace API_Tradingcenter.Models
{
    public class Order
    {
        public int OrderId{get; set;}
        public string Exchange{get; set;}
        public bool IsBuy{get; set;}
        public string Symbol{get; set;}
        public double Qty{get; set;}
        public double Currency{get; set;}
        public double Price{get; set;}
        public DateTime TimePlaced{get; set;}
    }
}