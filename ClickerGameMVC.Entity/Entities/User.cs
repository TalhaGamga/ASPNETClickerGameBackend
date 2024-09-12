using ClickerGameMVC.Entity.Entities;
using ClickerGameMVC.Entity.Interfaces;

namespace ClickerGameMVC.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string LetterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public int UserStatId { get; set; }

        public UserStat UserStat { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }
        public ICollection<UserItem> Items { get; set; }
    }
}