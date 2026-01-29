namespace TM.Excel.Back.Models
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Location? Location { get; set; }
    }
}
