﻿using System.Collections.Generic;
using System.Linq;
using WebApp.Entities;

namespace WebApp.Models
{
    public class OrderModel
    {
        public int[] products_id { get; set; }// ID продукта
        public int[] products_count { get; set; }// Количества продукта
        public string address { get; set; } = "";
        public string description { get; set; } = "";
        public int user_id { get; set; } = 0;
        public OrderStatus status { get; set; } = OrderStatus.Considered;

        public static void SetDictionary(string productsID, string productsCount, out int[] products_id, out int[] products_count)
        {
            products_id = productsID.Split(" ").Select(int.Parse).ToArray();
            products_count = productsCount.Split(" ").Select(int.Parse).ToArray();
        }

        public OrderModel(int[] products_id, int[] products_count, string address, string description, int user_id, OrderStatus status)
        {
            this.products_id = products_id;
            this.products_count = products_count;
            this.address = address;
            this.description = description;
            this.user_id = user_id;
            this.status = status;
        }
    }
}

/*
{
  "products_id": [
    0, 1
  ],
  "products_count": [
    2, 5
  ],
  "address": "Крауля 168",
  "description": "Доставить к охраннику",
  "userID": 0,
  "status": 0
}
 */
