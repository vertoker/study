using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Interfaces;
using System.Linq;

namespace WebApp.Services
{
    public class OrderService : IOrderService
    {
        private static List<order> _store = new List<order>();
        private static int counterID = 0;

        public void InitDB()
        {
            _store = ApplicationContextDB.GetOrders(out counterID);
        }
        public void AddOrder(Dictionary<int, int> products, string address, string description, OrderStatus orderStatus)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.Exception("Address was not received or empty");
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            counterID++;
            order order = new order()
            {
                ID = counterID,
                Address = address,
                Description = description,
                Status = (byte)orderStatus
            };
            order.SetDictionary(products);
            _store.Add(order);

            ApplicationContextDB.UpdateOrders(_store, counterID);
        }
        public void UpdateStatus(int id, OrderStatus orderStatus)
        {
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            var entity = GetOrder(id);
            entity.Status = (byte)orderStatus;

            ApplicationContextDB.UpdateOrders(_store, counterID);
        }
        public void UpdateStatus(int id, order entity, OrderStatus orderStatus)
        {
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            entity.Status = (byte)orderStatus;

            ApplicationContextDB.UpdateOrders(_store, counterID);
        }
        public order GetOrder(int id)
        {
            return _store.FirstOrDefault(item => item.ID == id);
        }
        public List<order> GetOrders()
        {
            return _store;
        }
    }
}
