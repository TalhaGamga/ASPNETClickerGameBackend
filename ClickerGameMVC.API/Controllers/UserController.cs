using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.User.Request;
using ClickerGameMVC.Common.DTOs.User.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickerGameMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserBusiness userBusiness, IHttpContextAccessor httpContextAccessor)
        {
            _userBusiness = userBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<ICollection<UserResponseDTO>> Get()
        {
            var users = _userBusiness.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Get(int id)
        {
            var userResponseDTO = _userBusiness.GetById(id);
            return Ok(userResponseDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Add([FromBody] UserCreateDTO userCreateDTO)
        {
            _userBusiness.Add(userCreateDTO);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Update([FromBody] UserEditDTO userEditDTO)
        {
            _userBusiness.Update(userEditDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var userResponseDTO = _userBusiness.Delete(id);
            return Ok(userResponseDTO);
        }

        [HttpPost("Edit Profile")]
        [Authorize(Roles = "User")]
        public IActionResult EditProfile(UserProfileEditDTO profileEditDTO)
        {
            var id = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst("Id")?.Value);
            var userResponseDTO = _userBusiness.EditProfile(id, profileEditDTO);

            return Ok(userResponseDTO);
        }

        [HttpPost("ClickUp")]
        [Authorize(Roles = "User")]
        public IActionResult ClickUp()
        {
            var id = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst("Id")?.Value);

            return Ok(_userBusiness.ClickUp(id));
        }
    }
}