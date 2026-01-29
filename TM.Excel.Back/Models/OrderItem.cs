using TM.Excel.Back.Enums;

namespace TM.Excel.Back.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public TicketTypeEnum TicketType { get; set; }
        public decimal Price { get; set; }
    }
}
