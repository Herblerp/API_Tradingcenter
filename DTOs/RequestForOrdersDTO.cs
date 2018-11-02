using System;

namespace API_Tradingcenter.DTOs
{
    public class RequestForOrdersDTO
    {
        public DateTime from{get; set;}
        public DateTime to {get; set;}
        public int userId{get; set;}
    }
}