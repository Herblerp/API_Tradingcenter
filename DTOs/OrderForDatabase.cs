using System.ComponentModel.DataAnnotations;

namespace API_Tradingcenter.DTOs
{
    public class OrderForDatabase
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Exchange { get; set; }
        [Required]
        public bool IsBuy { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public double Qty { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public double Price { get; set; }
    }
}