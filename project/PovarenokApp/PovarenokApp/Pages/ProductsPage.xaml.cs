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

using PovarenokApp.Scripts;
using PovarenokApp.Data;

namespace PovarenokApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page, IPage
    {
        public ProductsPage()
        {
            InitializeComponent();
            LViewServices.SelectionChanged += BtnProduct_Selection;
            //LViewServices. += BtnCart_Add;
        }

        public void Enable()
        {
            LViewServices.SelectionChanged -= BtnProduct_Selection;
            LViewServices.ItemsSource = null;
            LViewServices.ItemsSource = ApplicationContextDB.Products;
            LViewServices.SelectionChanged += BtnProduct_Selection;
        }
        public void Disable()
        {
            //LViewServices.ItemsSource = null;
        }

        private void BtnProduct_Selection(object sender, RoutedEventArgs e)
        {
            ProductPage.LoadProduct((ProductEntity)LViewServices.SelectedItem);
            MainWindow.OpenPage(2);
        }
        private void BtnCart_Add(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("12321");
        }

        public Visibility AdminButtonsVisibility
        {
            get
            {
                return AuthHolder.ActiveUser.IsAdmin() ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductPage.AddProduct();
            MainWindow.OpenPage(2);
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(3);
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = (ProductEntity)(sender as Button).DataContext;
            CartPage.AddProduct(product);
        }
    }
}
