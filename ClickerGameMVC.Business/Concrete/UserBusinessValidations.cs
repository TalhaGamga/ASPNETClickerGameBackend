using ClickerGameMVC.Common.DTOs.User.Request;

namespace ClickerGameMVC.Business.Concrete
{
    public partial class UserBusiness
    {
        private void UserCreateValidation(UserCreateDTO userCreateDTO)
        {
            if (string.IsNullOrWhiteSpace(userCreateDTO.Name))
            {
                throw new Exception("Name table cannot be empty");
            }
        }

        private void UserDeleteValidation(int id)
        {
            if (CheckUserExists(id))
            {
                return;
            }

            throw new Exception(string.Format("User with the {0} does not exist", id));
        }

        private void UserGetByIdValidation(int id)
        {
            if (CheckUserExists(id))
            {
                return;
            }

            throw new Exception(string.Format("User with the {0} does not exist", id));
        }

        private void UserUpdateValidation(int id)
        {
            if (CheckUserExists(id))
            {
                return;
            }

            throw new Exception(string.Format("User with the {0} does not exist", id));
        }

        private bool CheckUserExists(int id)
        {
            if (_userService.Contains(id))
            {
                return true;
            }

            return false;
        }
    }
}