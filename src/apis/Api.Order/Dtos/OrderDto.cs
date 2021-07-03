using System.Collections.Generic;

namespace Api.Order.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public uint Qty { get; set; }
    }
}
