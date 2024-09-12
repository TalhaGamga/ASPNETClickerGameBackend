using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Models;
using AutoMapper;
using ClickerGameMVC.Common.DTOs.User.Request;
using ClickerGameMVC.Common.DTOs.User.Response;
using ClickerGameMVC.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ClickerGameMVC.Business.Concrete
{
    public partial class UserBusiness : IUserBusiness
    {
        IService<User> _userService;
        IMapper _mapper;

        public UserBusiness(IService<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public void Add(UserCreateDTO userCreateDTO)
        {
            UserCreateValidation(userCreateDTO);

            var user = _mapper.Map<User>(userCreateDTO);
            user.Password = "*********";
            _userService.Add(user);
        }

        public UserResponseDTO Delete(int id)
        {
            UserDeleteValidation(id);

            var user = _userService.Delete(id);

            return new UserResponseDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            };
        }

        public ICollection<UserResponseDTO> GetAll()
        {
            var users = _userService.GetAll();
            var responseDTOs = _mapper.Map<List<UserResponseDTO>>(users);

            return responseDTOs;
        }

        public UserResponseDTO GetById(int id)
        {
            UserGetByIdValidation(id);

            var user = _userService.GetById(id);
            var responseDTO = _mapper.Map<UserResponseDTO>(user);

            return responseDTO;
        }

        public UserResponseDTO EditProfile(int id, UserProfileEditDTO profileEditDTO)
        {
            var user = _userService.GetById(id);
            _mapper.Map(user, profileEditDTO);
            _userService.Update(user);

            var responseDTO = _mapper.Map<UserResponseDTO>(user);

            return responseDTO;
        }

        public void Update(UserEditDTO userEditDTO)
        {
            UserUpdateValidation(userEditDTO.Id);

            var user = _userService.GetById(userEditDTO.Id);
            _mapper.Map(userEditDTO, user);
            _userService.Update(user);
        }

        public string ClickUp(int id)
        {
            var user = _userService.GetQueryable().Include(u => u.UserStat).FirstOrDefault(u => u.Id == id);
            int clickUp = 1;

            user.UserStat.ClickCount += clickUp;
            _userService.Update(user);

            return user.UserStat.ClickCount.ToString();
        }
    }
}