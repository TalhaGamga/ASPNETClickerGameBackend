using ClickerGameMVC.Common.DTOs.User;
using ClickerGameMVC.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClickerGameMVC.Presentation.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserController userController;

        [BindProperty]
        public UserRequestDTO User { get; set; } = new UserRequestDTO();

        public CreateModel(UserController userController)
        {
            this.userController = userController;
        }

        public void OnGet()
        { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            userController.Add(User);
            return RedirectToPage("/Users/Index");
        }
    }
}
