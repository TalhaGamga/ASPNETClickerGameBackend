using AutoMapper;
using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.User.Response;
using ClickerGameMVC.Service.Abstract;

namespace ClickerGameMVC.Business.Concrete
{
    public class LeaderboardBusiness : ILeaderboardBusiness
    {
        private readonly ILeaderboardService _lbService;
        private readonly IMapper _mapper;

        public LeaderboardBusiness(ILeaderboardService lbService, IMapper mapper)
        {
            _lbService = lbService;
            _mapper = mapper;
        }

        public ICollection<UserBoardDTO> GetAllnOrder(LeaderboardSortType sortType)
        {
            var users = _lbService.GetAllInOrder(sortType);
            var userBoardDTOs = _mapper.Map<List<UserBoardDTO>>(users);

            return userBoardDTOs;
        }
    }
}
