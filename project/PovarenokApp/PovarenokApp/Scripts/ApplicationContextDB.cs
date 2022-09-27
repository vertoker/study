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
    class ApplicationContextDB
    {
        #region DataBase
        public static List<Address> Addresses = new List<Address>()
        {
            new Address()
            {
                id = 0,
                address = "address 1"
            },
            new Address()
            {
                id = 1,
                address = "address 2"
            }
        };

        public static List<UserEntity> Users = new List<UserEntity>()
        {
            new UserEntity()
            {
                id = 0,
                first_name = "kostya",
                last_name = "churakov",
                patronymic = "eduardovich",
                login = "123",
                password = "321",
                role = (int)Role.Admin
            }
        };

        public static List<ProductEntity> Products = new List<ProductEntity>()
        {
            new ProductEntity()
            {
                id = 0,
                cost = 150,
                type = (int)ProductType.Fork,
                title = "fork 1",
                quantity_in_stock = 10,
                discount_amount = 0
            },
            new ProductEntity()
            {
                id = 1,
                cost = 200,
                type = (int)ProductType.Fork,
                title = "fork 2",
                quantity_in_stock = 25,
                discount_amount = 10
            },
            new ProductEntity()
            {
                id = 2,
                cost = 300,
                type = (int)ProductType.Spoon,
                title = "spoon 1",
                quantity_in_stock = 0,
                discount_amount = 5
            },
            new ProductEntity()
            {
                id = 3,
                cost = 400,
                type = (int)ProductType.Spoon,
                title = "spoon 2",
                quantity_in_stock = 1000,
                discount_amount = 15
            },
            new ProductEntity()
            {
                id = 4,
                cost = 500,
                type = (int)ProductType.Set,
                title = "set 1",
                quantity_in_stock = 999999,
                discount_amount = 5
            }
        };

        public static List<OrderEntity> Orders = new List<OrderEntity>()
        {
            new OrderEntity()
            {
                id = 0,
                order_products = "0 1",
                order_quantities = "3 2",
                date_order = "12.09.22",
                date_delivery = "14.09.22",
                code = 800,
                order_status = (int)OrderStatus.Complete
            },
            new OrderEntity()
            {
                id = 1,
                order_products = "0 1 2 3",
                order_quantities = "10 10 10 10",
                date_order = "16.09.22",
                date_delivery = "19.09.22",
                code = 801,
                order_status = (int)OrderStatus.New
            }
        };

        public static List<TableCounterEntity> Counters = new List<TableCounterEntity>()
        {
            new TableCounterEntity()//Addresses
            {
                id = 0,
                counter = 2
            },
            new TableCounterEntity()//Users
            {
                id = 1,
                counter = 1
            },
            new TableCounterEntity()//Products
            {
                id = 2,
                counter = 5
            },
            new TableCounterEntity()//Orders
            {
                id = 3,
                counter = 2
            }
        };
        #endregion

        public static void AddProduct(string title, float cost, int discount, int type)
        {
            Products.Add(new ProductEntity()
            {
                id = Counters[2].GetNext(),
                title = title,
                cost = cost,
                discount_amount = discount,
                type = type
            });
        }

        public static void EditProduct(int id, string title, float cost, int discount, int type)
        {
            int index = Products.FindIndex((ProductEntity p) => { return p.id == id; });
            Products[index] = new ProductEntity()
            {
                id = id,
                title = title,
                cost = cost,
                discount_amount = discount,
                type = type
            };
        }

        public static void DeleteProduct(int id)
        {
            int index = Products.FindIndex((ProductEntity p) => { return p.id == id; });
            Products.RemoveAt(index);
        }
    }
}
