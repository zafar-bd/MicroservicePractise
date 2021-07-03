using System.Collections.Generic;

namespace Common.Events
{
    public class OrderCreated
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
