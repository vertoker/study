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
        public void AddOrder(OrderModelPost orderModelPost)
        {
            if (string.IsNullOrEmpty(orderModelPost.address))
                throw new System.Exception("Address was not received or empty");
            if ((byte)orderModelPost.status > 2)
                throw new System.Exception("Order status is not selected");

            counterID++;
            order order = new order()
            {
                id = counterID,
                address = orderModelPost.address,
                description = orderModelPost.description,
                status = (byte)orderModelPost.status,
                user_id = orderModelPost.user_id
            };
            /*order.user_object = ApplicationContextDB.FindUser(order, orderModelPost.user_id);*/
            order.SetDictionary(orderModelPost.products_id, orderModelPost.products_count);
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
        public OrderModelGet GetOrder(int id)
        {
            var o = _store.FirstOrDefault(item => item.id == id);
            OrderModelGet.SetDictionary(o.products_id, o.products_count, out int[] products_id, out int[] products_count);
            var products_objects = FillProducts(products_id);
            return new OrderModelGet(products_objects, products_count, o.address, o.description, o.user_id, (OrderStatus)o.status);
        }
        public order GetOrderData(int id)
        {
            return _store.FirstOrDefault(item => item.id == id);
        }
        public List<OrderModelGet> GetOrders()
        {
            var result = new List<OrderModelGet>();
            var products = ApplicationContextDB.GetProducts();
            foreach (var o in _store)
            {
                OrderModelPost.SetDictionary(o.products_id, o.products_count, out int[] products_id, out int[] products_count);
                var products_objects = FillProducts(products_id, products);
                result.Add(new OrderModelGet(products_objects, products_count, o.address, o.description, o.user_id, (OrderStatus)o.status));
            }
            return result;
        }

        private ProductModel[] FillProducts(int[] products_id)
        {
            var products = ApplicationContextDB.GetProducts();
            return FillProducts(products_id, products);
        }
        private ProductModel[] FillProducts(int[] products_id, List<product> products)
        {
            int length = products_id.Length;
            ProductModel[] result = new ProductModel[length];
            for (int i = 0; i < length; i++)
            {
                var p = products.FirstOrDefault((product p) => { return p.id == products_id[i]; });
                result[i] = new ProductModel(p.name, p.description, p.price, p.photo_url);
            }
            return result;
        }
    }
}
