using ClickerGameMVC.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickerGameMVC.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserBusiness _userBusiness;

        public PlayerController(IUserBusiness userBusiness, IHttpContextAccessor httpContextAccessor)
        {
            _userBusiness = userBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("ClickUp")]
        [Authorize(Roles = "User")]
        public IActionResult ClickUp()
        {
            var id = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst("Id")?.Value);
            _userBusiness.ClickUp(id);
            return Ok("Clicked!" + $" {id}");
        }
    }
}