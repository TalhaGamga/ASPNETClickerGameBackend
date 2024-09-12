using ClickerGameMVC.Common.DTOs.User;
using ClickerGameMVC.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClickerGameMVC.Presentation.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserController userController;

        [BindProperty]
        public UserRequestDTO NewUser { get; set; } = new UserRequestDTO();

        [BindProperty]
        public UserRequestDTO UpdatedUser { get; set; } = new UserRequestDTO();

        public List<UserResponseDTO> Users { get; set; } = new List<UserResponseDTO>();

        public IndexModel(UserController userController)
        {
            this.userController = userController;
        }

        public void OnGet()
        {
            Users = userController.GetAll().ToList();
        }

        public IActionResult OnPostCreate()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            userController.Add(NewUser);
            return RedirectToPage("/Users/Index");
        }

        public IActionResult OnPostDelete(int id)
        {
            userController.Delete(id);
            return RedirectToPage("/Users/Index");
        }


        public IActionResult OnPostEdit(int id)
        {
            var user = userController.GetById(id);

            if (user != null)
            {
                UpdatedUser = new UserRequestDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                };
            }
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            userController.Update(UpdatedUser);
            return RedirectToPage("/Users/Index");
        }
    }
}