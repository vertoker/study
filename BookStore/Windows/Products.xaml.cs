using BookStore.DB;
using BookStore.Scripts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace BookStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page, IPage
    {
        public Products()
        {
            InitializeComponent();
        }

        public void Open()
        {
            ProductsGrid.ItemsSource = App.DB.Product.ToList();
        }
        public void Close()
        {

        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (ListViewItem)sender;
            if (item != null && item.IsSelected)
            {
                var product = (Product)item.DataContext;
                AppHandler.Cart.AddFrom(ref product);
                ProductsGrid.ItemsSource = App.DB.Product.ToList();
            }
        }
    }
}
