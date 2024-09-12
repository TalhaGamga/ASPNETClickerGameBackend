using ClickerGameMVC.Common.DTOs.User.Request;
using ClickerGameMVC.DataAccess.Repositories;
using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using Utils;
using BC = BCrypt.Net.BCrypt;

namespace ClickerGameMVC.Service.Service
{
    public class AuthService : IAuthService
    {
        IRepository<User> _repository;

        public AuthService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User GetById(string id)
        {
            return _repository.GetQuareyble().FirstOrDefault(u => u.LetterId == id);
        }

        public User GetByEmail(string email)
        {
            return _repository.GetQuareyble().FirstOrDefault(c => c.Email == email);
        }

        public void Register(User model)
        {
            var letterId = IdGenerator.CreateLetterId(10);
            model.LetterId = letterId;
            model.Password = BC.HashPassword(model.Password);

            _repository.Add(model);
            _repository.SaveChanges();
        }

        public string DecodeEmailFromToken(string token)
        {
            var decodedToken = new JwtSecurityTokenHandler();
            var indexOfTokenValue = 7;
            var t = decodedToken.ReadJwtToken(token.Substring(indexOfTokenValue));

            return t.Payload.FirstOrDefault(x => x.Key == "email").Value.ToString();
        }

        public bool Contains(string Email)
        {
            return _repository.GetQuareyble().Any(u => u.Email == Email);
        }

        public User Login(UserLoginDTO userLoginDTO)
        {
            return GetByEmail(userLoginDTO.Email);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}