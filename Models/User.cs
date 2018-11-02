using System;

namespace API_Tradingcenter.Models
{
    public class User
    {
        public int UserId {get; set;}
        public string Username {get; set;}
        public DateTime RegisteredOn{get; set;}
        public byte[] PasswordHash{get; set;}
        public byte[] PasswordSalt{get; set;}
    }
}