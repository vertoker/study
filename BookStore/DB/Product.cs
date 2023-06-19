using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BookStore.DB
{
    public class Product
    {
        public Product()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public int Quantity { get; set; }
        public int idManufacture { get; set; }
        public string ImagePath { get; set; }

        public string ImageSource
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePath)) return null;

                var resDirectory = "Resources/Images/";
                var baseDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var path = Path.Combine(baseDirectory, resDirectory, ImagePath);
                return path;
            }
        }


        public decimal TotalPrice
        {
            get
            {
                if (Discount.HasValue)
                {
                    var priceMultiplier = (decimal)(1f - Discount.Value / 100f);
                    return Price * priceMultiplier;
                }
                return Price;
            }
        }

        public string TotalPriceString => $"{TotalPrice}₽";

        public Manufacture Manufacture { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

    }
}
