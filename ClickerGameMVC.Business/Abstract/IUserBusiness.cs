using ClickerGameMVC.Common.DTOs.User.Request;
using ClickerGameMVC.Common.DTOs.User.Response;

namespace ClickerGameMVC.Business.Abstract
{
    public interface IUserBusiness
    {
        UserResponseDTO GetById(int id);
        ICollection<UserResponseDTO> GetAll();
        public void Add(UserCreateDTO userCreateDTO);
        public void Update(UserEditDTO userEditDTO);
        public UserResponseDTO EditProfile(int id, UserProfileEditDTO profileEditDTO);
        public UserResponseDTO Delete(int id);

        public string ClickUp(int id);
    }
}