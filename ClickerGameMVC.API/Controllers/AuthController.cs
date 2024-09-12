using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickerGameMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public ActionResult<string> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _authBusiness.Register(userRegisterDTO);
                    return Ok("Succesfully Registered!");
                }

                return BadRequest(ModelState);
            }

            catch (Exception error)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult<string> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userAuthDTO = _authBusiness.Login(userLoginDTO);
                    var token = _authBusiness.GenerateJwtToken(userAuthDTO);

                    return Ok(token);
                }

                return BadRequest(ModelState);
            }

            catch (Exception error)
            {
                return StatusCode(500);
            }
        }
    }
}