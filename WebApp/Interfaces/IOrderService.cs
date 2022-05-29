using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IOrderService
    {
        void InitDB();
        void AddOrder(OrderModelPost orderModelPost);
        void UpdateStatus(int id, order entity, OrderStatus orderStatus);
        OrderModelGet GetOrder(int id);
        order GetOrderData(int id);
        List<OrderModelGet> GetOrders();
    }
}
