namespace ClickerGameMVC.Common.Models
{
    public class EventInputModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}