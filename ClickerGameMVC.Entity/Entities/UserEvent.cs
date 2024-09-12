using ClickerGameMVC.Entity.Interfaces;
using ClickerGameMVC.Models;

namespace ClickerGameMVC.Entity.Entities
{
    public class UserEvent : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}