using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace ClickerGameMVC.Presentation.Controllers
{
    public class UserController : Controller
    {
        IUserBusiness userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        public UserResponseDTO GetById(int id)
        {
            return userBusiness.GetById(id);
        }

        public ICollection<UserResponseDTO> GetAll()
        {
            return userBusiness.GetAll();
        }

        public void Add(UserCreateDTO userCreateDTO)
        {
            userBusiness.Add(userCreateDTO);
        }

        public void Update(UserEditDTO userEditDTO)
        {
            userBusiness.Update(userEditDTO);
        }

        public void Delete(int id)
        {
            userBusiness.Delete(id);
        }

        public async Task<IActionResult> Index()
        {
            var users = await Task.Run(() => userBusiness.GetAll().ToList());
            return View(users);
        }
    }
}