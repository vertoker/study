using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BookStore.DB
{
    public class Image
    {
        private static readonly ImageSourceConverter _imageSourceConverter = new ImageSourceConverter();

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public Image()
        {
            Product = new HashSet<Product>();
        }

        public BitmapImage BitmapImage => ToImage(Data);

        public int id { get; set; }
        public byte[] Data { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
