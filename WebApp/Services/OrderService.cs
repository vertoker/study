using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Models;
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
            _store = ApplicationContextDB.GetOrders(ref counterID);
        }
        public void AddOrder(int[] productsID, int[] productsCount, string address, string description, OrderStatus orderStatus, int userID)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.Exception("Address was not received or empty");
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            counterID++;
            order order = new order()
            {
                id = counterID,
                address = address,
                description = description,
                status = (byte)orderStatus,
                user_id = userID
            };
            order.user_object = ApplicationContextDB.FindUser(order, userID);
            order.SetDictionary(productsID, productsCount);
            _store.Add(order);

            ApplicationContextDB.UpdateOrders(_store, counterID);
        }
        public void UpdateStatus(int id, order entity, OrderStatus orderStatus)
        {
            if ((byte)orderStatus > 2)
                throw new System.Exception("Order status is not selected");

            entity.status = (byte)orderStatus;

            ApplicationContextDB.UpdateOrders(_store, counterID);
        }
        public OrderModel GetOrder(int id)
        {
            var o = _store.FirstOrDefault(item => item.id == id);
            OrderModel.SetDictionary(o.products_id, o.products_count, out int[] products_id, out int[] products_count);
            return new OrderModel(products_id, products_count, o.address, o.description, o.user_id, (OrderStatus)o.status);
        }
        public order GetOrderData(int id)
        {
            return _store.FirstOrDefault(item => item.id == id);
        }
        public List<OrderModel> GetOrders()
        {
            var result = new List<OrderModel>();
            foreach (var o in _store)
            {
                OrderModel.SetDictionary(o.products_id, o.products_count, out int[] products_id, out int[] products_count);
                result.Add(new OrderModel(products_id, products_count, o.address, o.description, o.user_id, (OrderStatus)o.status));
            }
            return result;
        }
    }
}
