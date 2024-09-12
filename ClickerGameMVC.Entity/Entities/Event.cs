using ClickerGameMVC.Entity.Interfaces;

namespace ClickerGameMVC.Entity.Entities
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public string LetterId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; }
    }
}