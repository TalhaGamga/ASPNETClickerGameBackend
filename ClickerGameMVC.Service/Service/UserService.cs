using ClickerGameMVC.DataAccess.Repositories;
using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstract;

namespace ClickerGameMVC.Service.Service
{
    public class UserService : ServiceBase<User>
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}