using ClickerGameMVC.Common.DTOs.User.Request;

namespace ClickerGameMVC.Business.Abstract
{
    public interface IAuthBusiness
    {
        public void Register(UserRegisterDTO userRegisterDTO);
        public UserAuthDTO Login(UserLoginDTO userLoginDTO);
        public string GenerateJwtToken(UserAuthDTO userAuthDTO);
    }
}