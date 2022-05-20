using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Entities
{
    public class order
    {
        [Required, Key]
        public int ID { get; set; }
        public string Products { get; set; }// ID продукта и его количество
        public string Address { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public int UserID { get; set; }
        public user UserObject { get; set; }

        public void SetDictionary(Dictionary<int, int> products)
        {
            Products = string.Join(' ', products);
            Products.Replace('[', ' ');
            Products.Replace(',', ' ');
            Products.Replace(']', ' ');
        }
    }
}

public enum OrderStatus : byte
{
    Considered = 0,
    Accepted = 1,
    Cancelled = 2
}