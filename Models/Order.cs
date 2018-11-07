using System;
using System.ComponentModel.DataAnnotations;

namespace API_Tradingcenter.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
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
        [Required]
        public DateTime TimePlaced { get; set; }
    }
}