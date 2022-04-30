using System.Collections.Generic;
using WebApp.Entities;

namespace WebApp.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(Dictionary<int, int> products, string address, string description, OrderStatus orderStatus);
        void UpdateStatus(int id, OrderStatus orderStatus);
        void UpdateStatus(int id, OrderEntity entity, OrderStatus orderStatus);
        OrderEntity GetOrder(int id);
        List<OrderEntity> GetOrders();
    }
}
