using System.ComponentModel.DataAnnotations;

namespace API_Tradingcenter.DTOs
{
    public class UserToRegisterDTO
    {
        [Required]
        public string Username{ get; set;}

        [Required]
        [StringLength(20,MinimumLength = 4, ErrorMessage = "Password must be between 4 and 20 characters long")]
        public string Password{get; set;}

        [Required]
        public string Email{get; set;}
    }
}