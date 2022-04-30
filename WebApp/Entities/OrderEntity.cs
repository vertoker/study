using System.Collections.Generic;

namespace WebApp.Entities
{
    public class OrderEntity
    {
        public int ID { get; set; }
        public Dictionary<int, int> Products { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
    }
}

public enum OrderStatus : byte
{
    Considered = 0,
    Accepted = 1,
    Cancelled = 2
}