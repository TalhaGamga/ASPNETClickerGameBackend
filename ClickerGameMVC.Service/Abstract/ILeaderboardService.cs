using ClickerGameMVC.Models;

namespace ClickerGameMVC.Service.Abstract
{
    public interface ILeaderboardService
    {
        public ICollection<User> GetAllInOrder(LeaderboardSortType sortType);
    }
}