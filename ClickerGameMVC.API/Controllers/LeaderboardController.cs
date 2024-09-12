using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.User.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ClickerGameMVC.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        ILeaderboardBusiness _lbBusiness;

        public LeaderboardController(ILeaderboardBusiness lbBusiness)
        {
            _lbBusiness = lbBusiness;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<ICollection<UserBoardDTO>> GetAllInOrder(LeaderboardSortType sortType)
        {
            var userBoardDTOs = _lbBusiness.GetAllnOrder(sortType);
            return Ok(userBoardDTOs);
        }
    }
}
