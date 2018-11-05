using System;
using System.ComponentModel.DataAnnotations;

namespace API_Tradingcenter.DTOs
{
    public class DateRangeDTO
    {
        [Required]
        public DateTime dateFrom{get; set;}
        [Required]
        public DateTime dateTo {get; set;}
    }
}