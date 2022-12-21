using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PovarenokApp.Data;
using PovarenokApp.Data.Enum;

namespace PovarenokApp.Scripts
{
    public static class ApplicationContextDB
    {
        private const bool local = true;

        private static PovarenokEntities1 DB { get; } = new PovarenokEntities1();
        public static List<Counters> Counters { get; } = local ? DB.CountersLocal : DB.Counters.ToList();
        public static List<Addresses> Addresses { get; } = local ? DB.AddressesLocal : DB.Addresses.ToList();
        public static List<Users> Users { get; } = local ? DB.UsersLocal : DB.Users.ToList();
        public static List<Products> Products { get; } = local ? DB.ProductsLocal : DB.Products.ToList();
        public static List<Orders> Orders { get; } = local ? DB.OrdersLocal : DB.Orders.ToList();

        public static void AddProduct(int id, string title, float cost, int discount, int type, int quantity)
        {
            Products.Add(new Products()
            {
                ProductID = id,
                ProductName = title,
                ProductCost = (decimal)cost,
                ProductDiscountAmount = (byte)discount,
                ProductCategory = type,
                ProductQuantityInStock = quantity
            });
        }

        public static void EditProduct(int id, string title, float cost, int discount, int type, int quantity)
        {
            int index = Products.FindIndex((Products p) => { return p.ProductID == id; });
            Products[index] = new Products()
            {
                ProductID = id,
                ProductName = title,
                ProductCost = (decimal)cost,
                ProductDiscountAmount = (byte)discount,
                ProductCategory = type,
                ProductQuantityInStock = quantity
            };
        }

        public static void DeleteProduct(int id)
        {
            int index = Products.FindIndex((Products p) => { return p.ProductID == id; });
            Products.RemoveAt(index);
        }

        public static void CreateOrder(List<CartProduct> products)
        {
            foreach (var p in Products)
            {
                foreach (var cp in products)
                {
                    //MessageBox.Show(string.Join(" ", p.id, cp.id, p.quantity_in_stock, cp.quantity));
                    if (p.ProductID == cp.id)
                    {
                        p.ProductQuantityInStock -= cp.quantity;
                    }
                }
            }

            var order = new Orders()
            {
                OrderID = Counters[3].GetNext(),
                OrderProducts = string.Join(" ", products.Select((CartProduct cp) => { return cp.id; })),
                OrderQuantities = string.Join(" ", products.Select((CartProduct cp) => { return cp.quantity; })),
                OrderOrderDate = DateTime.Now,
                OrderDeliveryDate = DateTime.Now.AddDays(7),
                OrderStatus = (int)OrderStatus.New
            };
            Orders.Add(order);
        }
    }
}
