using ClickerGameMVC.Common.DTOs.User.Request;
using ClickerGameMVC.Models;

namespace ClickerGameMVC.Service.Abstract
{
    public interface IAuthService
    {
        void Register(User user);
        User Login(UserLoginDTO userLoginDTO);
        public User GetByEmail(string email);
        bool Contains(string Email);
        void SaveChanges();
    }
}