namespace ClickerGameMVC.Common.Models
{
    public class EventBindingModel
    {
        public string LetterId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public ICollection<int> UserIds { get; set; }
    }
}
