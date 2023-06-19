using BookStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public void CreateCurrentOrder()
        {
            if (CurrentOrder == null)
            {
                CurrentOrder = new Order
                {
                    idAddress = (int)AddressEnum.Yandex,
                    idStatus = (int)StatusEnum.InProgress
                };
                App.DB.Order.Add(CurrentOrder);
                App.DB.SaveChanges();
            }
        }

        public void AddFrom(ref Product product)
        {
            if (product.Quantity <= 0) return;

            CreateCurrentOrder();

            var idProduct = product.id;
            var orderProduct = CurrentOrder.OrderProduct.FirstOrDefault(op => op.idProduct == idProduct);
            var mustAddNewOrderProduct = orderProduct == null;

            if (mustAddNewOrderProduct)
            {
                orderProduct = new OrderProduct()
                {
                    idOrder = CurrentOrder.id,
                    idProduct = idProduct,
                    Quantity = 0
                };
            }

            product.Quantity--;
            orderProduct.Quantity++;

            if (mustAddNewOrderProduct)
                App.DB.OrderProduct.Add(orderProduct);

            App.DB.SaveChanges();
        }

        public void RemoveFrom(ref OrderProduct orderProduct)
        {
            if (orderProduct.Quantity <= 0) return;

            var idProduct = orderProduct.idProduct;
            var product = App.DB.Product.FirstOrDefault(op => op.id == idProduct);

            orderProduct.Quantity--;
            product.Quantity++;

            if (orderProduct.Quantity == 0)
                App.DB.OrderProduct.Remove(orderProduct);

            App.DB.SaveChanges();
        }

        public void Order()
        {
            if (CurrentOrder.OrderProduct.Count > 0)
            {
                CurrentOrder.idStatus = (int)StatusEnum.WaitDelivery;
                App.DB.SaveChanges();

                MessageBox.Show($"Вы потратили {CurrentOrder.TotalPrice}₽");
                CurrentOrder = null;
            }
        }
    }
}
