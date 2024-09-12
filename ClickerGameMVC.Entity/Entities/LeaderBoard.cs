using ClickerGameMVC.Entity.Interfaces;

namespace ClickerGameMVC.Models
{
    public class LeaderBoard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GoldAmount { get; set; }
        public int ClickCount { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
