using BookStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Scripts
{
    public class CartHandler
    {
        public Order CurrentOrder { get; private set; } = null;

        public CartHandler()
        {
            LoadCurrentOrder();
        }
        private void LoadCurrentOrder()
        {
            CurrentOrder = App.DB.Order.FirstOrDefault(o => o.idStatus == (int)StatusEnum.InProgress);
        }
        private void CreateCurrentOrder()
        {
            CurrentOrder = new Order
            {
                idAddress = (int)AddressEnum.Yandex,
                idStatus = (int)StatusEnum.InProgress
            };
            App.DB.Order.Add(CurrentOrder);
        }

        public void AddFrom(Product product)
        {
            if (product.Quantity <= 0) return;

            if (CurrentOrder == null)
                CreateCurrentOrder();

            var orderProduct = CurrentOrder.OrderProduct.FirstOrDefault(op => op.idProduct == product.id);
            var mustAddNewOrderProduct = orderProduct == null;

            if (mustAddNewOrderProduct)
            {
                orderProduct = new OrderProduct()
                {
                    idOrder = CurrentOrder.id,
                    idProduct = product.id,
                    Quantity = 0
                };
            }

            product.Quantity--;
            orderProduct.Quantity++;

            if (mustAddNewOrderProduct)
                App.DB.OrderProduct.Add(orderProduct);
        }

        public void RemoveFrom(OrderProduct orderProduct)
        {
            if (orderProduct.Quantity <= 0) return;

            var product = App.DB.Product.FirstOrDefault(op => op.id == orderProduct.idProduct);

            orderProduct.Quantity--;
            product.Quantity++;

            App.DB.OrderProduct.Remove(orderProduct);
        }

        public void Order()
        {
            CurrentOrder.idStatus = (int)StatusEnum.WaitDelivery;
            CurrentOrder = null;
        }
    }
}
