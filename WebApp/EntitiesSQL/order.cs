using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Entities
{
    public class order
    {
        [Required, Key]
        public int id { get; set; }
        public string products_id { get; set; }// ID продукта
        public string products_count { get; set; }// Количества продукта
        public string address { get; set; }
        public string description { get; set; }
        public byte status { get; set; }

        public int user_id { get; set; }
        //public user user_object { get; set; }

        public void SetDictionary(int[] productsID, int[] productsCount)
        {
            products_id = string.Join(" ", productsID);
            products_count = string.Join(" ", productsCount);
        }
    }
}

public enum OrderStatus : byte
{
    Considered = 0,
    Accepted = 1,
    Cancelled = 2
}