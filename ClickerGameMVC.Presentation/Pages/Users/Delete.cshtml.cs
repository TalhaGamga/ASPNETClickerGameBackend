using ClickerGameMVC.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClickerGameMVC.Presentation.Pages.Users
{
    public class DeleteModel : PageModel
    {
        UserController userController;
        [BindProperty] public int Id { get; set; }

        public DeleteModel(UserController userController)
        {
            this.userController = userController;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            userController.Delete(Id);
            return RedirectToPage("/Users/Index");
        }
    }
}
