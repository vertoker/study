using System.Collections.Generic;

namespace WebApp.Models
{
    public class OrderModel
    {
        public Dictionary<int, int> Products { get; set; } = new Dictionary<int, int>() { { 0, 2 }, { 1, 2 } };
        public string Address { get; set; } = "";
        public string Description { get; set; } = "";
        public OrderStatus Status { get; set; } = OrderStatus.Considered;
    }
}

/*
{
  "products": {
    0: 2,
    1: 5
  },
  "address": "Крауля 168",
  "description": "Доставить к охраннику",
  "status": 0
}
 */
