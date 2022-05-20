using System.Collections.Generic;
using WebApp.Entities;

namespace WebApp.Interfaces
{
    public interface IOrderService
    {
        void InitDB();
        void AddOrder(Dictionary<int, int> products, string address, string description, OrderStatus orderStatus);
        void UpdateStatus(int id, OrderStatus orderStatus);
        void UpdateStatus(int id, order entity, OrderStatus orderStatus);
        order GetOrder(int id);
        List<order> GetOrders();
    }
}
