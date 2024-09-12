using ClickerGameMVC.Common.DTOs.User.Request;
using BC = BCrypt.Net.BCrypt;

namespace ClickerGameMVC.Business.Concrete
{
    public partial class AuthBusiness
    {
        private void RegisterValidation(UserRegisterDTO userRegisterDTO)
        {
            if (!HasPasswordConfirmed(userRegisterDTO.Password, userRegisterDTO.ConfirmedPassword))
            {
                throw new Exception("Passwords does not match");
            }

            if (CheckUserExists(userRegisterDTO.Email))
            {
                throw new Exception($"{userRegisterDTO.Email} is already used!");
            }
        }

        private void LoginValidation(UserLoginDTO userLoginDTO)
        {
            if (CheckUserExists(userLoginDTO.Email) && IsAuthenticated(userLoginDTO.Email, userLoginDTO.Password))
            {
                return;
            }

            throw new Exception("Email address or password is incorrect!");
        }

        private bool CheckUserExists(string email)
        {
            if (_authService.Contains(email))
            {
                return true;
            }

            return false;
        }

        private bool HasPasswordConfirmed(string password, string confirmation)
        {
            if (password != confirmation)
            {
                return false;
            }

            return true;
        }

        private bool IsAuthenticated(string email, string password)
        {
            var user = _authService.GetByEmail(email);
            return BC.Verify(password, user.Password);
        }
    }
}
