using System.ComponentModel.DataAnnotations;

namespace ClickerGameMVC.Common.DTOs.User.Request
{
    public class UserLoginDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}