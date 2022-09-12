using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                description = "fork 1",
                quantity_in_stock = 10,
                discount_amount = 0
            },
            new ProductEntity()
            {
                id = 1,
                cost = 200,
                type = (int)ProductType.Fork,
                description = "fork 2",
                quantity_in_stock = 25,
                discount_amount = 10
            },
            new ProductEntity()
            {
                id = 2,
                cost = 300,
                type = (int)ProductType.Spoon,
                description = "spoon 1",
                quantity_in_stock = 0,
                discount_amount = 5
            },
            new ProductEntity()
            {
                id = 3,
                cost = 400,
                type = (int)ProductType.Spoon,
                description = "spoon 2",
                quantity_in_stock = 1000,
                discount_amount = 15
            },
            new ProductEntity()
            {
                id = 4,
                cost = 500,
                type = (int)ProductType.Set,
                description = "fork 1",
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
        #endregion
    }
}
