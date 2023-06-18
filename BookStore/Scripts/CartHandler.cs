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
        private Order _currentOrder = null;

        public CartHandler()
        {
            LoadCurrentOrder();
        }
        private void LoadCurrentOrder()
        {
            _currentOrder = App.DB.Order.FirstOrDefault(o => o.StatusEnum == StatusEnum.InProgress);
        }
        private void CreateCurrentOrder()
        {
            _currentOrder = new Order
            {
                AddressEnum = AddressEnum.Yandex,
                StatusEnum = StatusEnum.InProgress
            };
            App.DB.Order.Add(_currentOrder);
        }

        public void AddFrom(Product product)
        {
            if (product.Quantity <= 0) return;

            if (_currentOrder == null)
                CreateCurrentOrder();

            var orderProduct = _currentOrder.OrderProduct.FirstOrDefault(op => op.idProduct == product.id);
            var mustAddNewOrderProduct = orderProduct == null;

            if (mustAddNewOrderProduct)
            {
                orderProduct = new OrderProduct()
                {
                    idOrder = _currentOrder.id,
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
            _currentOrder.StatusEnum = StatusEnum.WaitDelivery;
            _currentOrder = null;
        }
    }
}
