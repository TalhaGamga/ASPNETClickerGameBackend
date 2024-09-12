using ClickerGameMVC.DataAccess.Repositories;
using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstract;

namespace ClickerGameMVC.Service.Service
{
    public class ItemService : ServiceBase<Item>
    {
        public ItemService(IRepository<Item> repository) : base(repository)
        {
        }
    }
}
