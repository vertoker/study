using PovarenokApp.Data;
using PovarenokApp.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PovarenokApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page, IPage
    {
        private List<int> products = new List<int>();
        private List<int> quantities = new List<int>();
        private static CartPage instance;

        public CartPage()
        {
            InitializeComponent();
            instance = this;
        }

        public void Enable()
        {
            UpdateCart();
        }
        public void Disable()
        {

        }

        public static void AddProduct(int id)
        {
            var index = instance.products.IndexOf(id);
            if (index != -1)
            {
                instance.products.Add(id);
                instance.quantities.Add(0);
            }
            else
            {
                instance
            }
        }
        public void UpdateCart()
        {
            List<ProductEntity> productEntities = new List<ProductEntity>();
            for (int i = 0; i < products.Count; i++)
            {
                var product = ApplicationContextDB.Products.FirstOrDefault((ProductEntity p) => { return p.id == products[i]; });
                if (!product.IsEmpty())
                {
                    productEntities.Add(product);
                }
            }
            //Здесь UI отображение
        }
    }
}
