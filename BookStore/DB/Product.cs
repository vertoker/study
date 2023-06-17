using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DB
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Discount { get; set; }
        public int idManufacture { get; set; }
        public Nullable<int> idImage { get; set; }

        public Manufacture Manufacture { get; set; }
        public Image Image { get; set; }
    }
}
