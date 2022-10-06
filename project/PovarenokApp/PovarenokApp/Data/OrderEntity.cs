using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarenokApp.Data
{
    public class OrderEntity
    {
        public int id;
        public string order_products;
        public string order_quantities;
        public string date_order;
        public string date_delivery;
        public int id_address;
        public int id_user;
        public int code;
        public int order_status;
    }
}
