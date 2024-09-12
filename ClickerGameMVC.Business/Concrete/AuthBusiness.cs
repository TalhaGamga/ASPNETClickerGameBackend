using AutoMapper;
using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.User.Request;
using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClickerGameMVC.Business.Concrete
{
    public partial class AuthBusiness : IAuthBusiness
    {
        IAuthService _authService;
        IMapper _mapper;
        IConfiguration _configuration;

        public AuthBusiness(IAuthService authService, IMapper mapper, IConfiguration configuration)
        {
            _authService = authService;
            _mapper = mapper;
            _configuration = configuration;
        }
        public UserAuthDTO Login(UserLoginDTO userLoginDTO)
        {
            LoginValidation(userLoginDTO);

            var user = _authService.Login(userLoginDTO);
            var userAuthDTO = _mapper.Map<User, UserAuthDTO>(user);

            _authService.Login(userLoginDTO);

            return userAuthDTO;
        }

        public void Register(UserRegisterDTO userRegisterDTO)
        {
            RegisterValidation(userRegisterDTO);

            var user = _mapper.Map<UserRegisterDTO, User>(userRegisterDTO);
            user.Role = "User";

            UserStat userStat = new UserStat() { ClickCount = 0, GoldAmount = 0 };
            user.UserStat = userStat;

            _authService.Register(user);

            user.UserStatId = userStat.Id;

            userStat.User = user;
            userStat.UserId = user.Id;

            _authService.SaveChanges();
        }



        public string GenerateJwtToken(UserAuthDTO userAuthDTO)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>()
            {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iss, issuer),
                    new Claim(ClaimTypes.Email, userAuthDTO.Email),
                    new Claim("Id", userAuthDTO.Id.ToString()),
                    new Claim(ClaimTypes.Role,userAuthDTO.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}