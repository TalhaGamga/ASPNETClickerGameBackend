using ClickerGameMVC.Entity.Interfaces;

namespace ClickerGameMVC.Models
{
    public class UserStat : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GoldAmount { get; set; }
        public int ClickCount { get; set; }

        public User User { get; set; }
    }
}