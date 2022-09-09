using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PovarenokApp.Data.Enum;

namespace PovarenokApp.Data
{
    struct ProductModel
    {
        public ProductType Type;
        public int DiscountAmount;
        public int QuantityInStock;
        public string Description;
        public byte[] Image;

        public string DiscountText
        {
            get
            {
                if (DiscountAmount == 0)
                    return string.Empty;
                else
                    return $"* Скидка {DiscountAmount}%";
            }
        }
    }
}
