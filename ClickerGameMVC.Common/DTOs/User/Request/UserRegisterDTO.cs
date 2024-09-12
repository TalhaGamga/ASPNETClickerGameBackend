using System.ComponentModel.DataAnnotations;

namespace ClickerGameMVC.Common.DTOs.User.Request
{
    public class UserRegisterDTO
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmedPassword { get; set; }
    }
}