using ClickerGameMVC.Common.DTOs.User.Response;

namespace ClickerGameMVC.Business.Abstract
{
    public interface ILeaderboardBusiness
    {
        ICollection<UserBoardDTO> GetAllnOrder(LeaderboardSortType sortType);
    }
}
