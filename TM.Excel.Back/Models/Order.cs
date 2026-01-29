namespace TM.Excel.Back.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Person? Buyer { get; set; }
        public Event? Event { get; set; }
        public List<OrderItem> Items { get; set; } = [];
    }
}
