using AutoMapper;
using ClickerGameMVC.Common.DTOs.User.Request;
using ClickerGameMVC.Common.DTOs.User.Response;
using ClickerGameMVC.Models;

namespace ClickerGameMVC.API
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<UserCreateDTO, User>();

            CreateMap<User, UserResponseDTO>();

            CreateMap<UserEditDTO, User>();

            CreateMap<UserRegisterDTO, User>();

            CreateMap<User, UserRegisterDTO>();

            CreateMap<User, UserAuthDTO>();

            CreateMap<UserAuthDTO, User>();

            CreateMap<UserLoginDTO, UserAuthDTO>();

            CreateMap<User, UserBoardDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.ClickCount, opt => opt.MapFrom(src => src.UserStat.ClickCount))
            .ForMember(dest => dest.GoldAmount, opt => opt.MapFrom(src => src.UserStat.GoldAmount));

            CreateMap<UserProfileEditDTO, User>();
            CreateMap<UserProfileEditDTO, UserResponseDTO>();
        }
    }
}