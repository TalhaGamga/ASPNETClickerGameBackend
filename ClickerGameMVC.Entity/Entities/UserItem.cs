using ClickerGameMVC.Entity.Interfaces;

namespace ClickerGameMVC.Models
{
    public class UserItem : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UpgradeItemId { get; set; }
        public int Level { get; set; }
        public string PurchaseDate { get; set; }

        public User User { get; set; }
        public Item Item { get; set; }
    }
}
