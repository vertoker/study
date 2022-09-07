using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarenokApp.DataBase
{
    struct Product
    {
        public ProductType Type;
        public int DiscountAmount;
        public int QuantityInStock;
        public string Description;
        public string Image;
    }
}
