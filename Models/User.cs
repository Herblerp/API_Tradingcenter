using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Tradingcenter.Models
{
    public class User
    {
        public int UserId {get; set;}
        [Required]
        public string Username {get; set;}
        [Required]
        public string Email{get; set;}
        [Required]
        public DateTime RegisteredOn{get; set;}
        [Required]
        public byte[] PasswordHash{get; set;}
        [Required]
        public byte[] PasswordSalt{get; set;}
        public List<Order> Orders{get; set;}
        public DateTime LastRefresh{get; set;}

    }
}