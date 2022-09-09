using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PovarenokApp.Data.Enum;

namespace PovarenokApp.Data
{
    class ProductEntity
    {
        public int id;
        public ProductType type;
        public int discount_amount;
        public int quantity_in_stock;
        public string description;
        public byte[] image;
    }
}
