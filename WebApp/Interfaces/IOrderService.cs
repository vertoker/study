using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IOrderService
    {
        void InitDB();
        void AddOrder(int[] productsID, int[] productsCount, string address, string description, OrderStatus orderStatus, int userID);
        void UpdateStatus(int id, order entity, OrderStatus orderStatus);
        OrderModel GetOrder(int id);
        order GetOrderData(int id);
        List<OrderModel> GetOrders();
    }
}
