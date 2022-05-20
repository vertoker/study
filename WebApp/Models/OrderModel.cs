using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class OrderModel
    {
        public Dictionary<int, int> Products { get; set; } = new Dictionary<int, int>() { { 0, 2 }, { 1, 2 } };
        public string Address { get; set; } = "";
        public string Description { get; set; } = "";
        public OrderStatus Status { get; set; } = OrderStatus.Considered;

        public void SetDictionary(string products)
        {
            int[] data = products.Split(' ').Select(int.Parse).ToArray();
            int length = data.Length;

            Products = new Dictionary<int, int>();
            for (int i = 0; i < length; i += 2)
                Products.Add(data[i], data[i + 1]);
        }
    }
}

/*
{
  "products": {
    "0": 2,
    "1": 5
  },
  "address": "Крауля 168",
  "description": "Доставить к охраннику",
  "status": 0
}
 */
