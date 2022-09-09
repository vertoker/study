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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public class TestProduct
        {
            public string Title;
        }

        private static TestProduct[] test = new TestProduct[] 
        {
            new TestProduct(){ Title = "Товар 1" },
            new TestProduct(){ Title = "Товар 2" }
        };

        public ProductsPage()
        {
            InitializeComponent();

            LViewServices.ItemsSource = test;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
