using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Interfaces;
using System.Linq;

namespace WebApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly static List<OrderEntity> _store = new List<OrderEntity>();
        private static int counterID = 0;

        public void AddOrder(Dictionary<int, int> products, string address, string description, OrderStatus orderStatus)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.Exception("Address was not received or empty");
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            counterID++;
            OrderEntity order = new OrderEntity()
            {
                ID = counterID,
                Products = products,
                Address = address,
                Description = description,
                Status = orderStatus
            };
            _store.Add(order);
        }
        public void UpdateStatus(int id, OrderStatus orderStatus)
        {
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            var entity = GetOrder(id);
            entity.Status = orderStatus;
        }
        public void UpdateStatus(int id, OrderEntity entity, OrderStatus orderStatus)
        {
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            entity.Status = orderStatus;
        }
        public OrderEntity GetOrder(int id)
        {
            return _store.FirstOrDefault(item => item.ID == id);
        }
        public List<OrderEntity> GetOrders()
        {
            return _store;
        }
    }
}
