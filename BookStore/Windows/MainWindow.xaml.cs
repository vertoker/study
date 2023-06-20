using BookStore.DB;
using BookStore.Scripts;
using BookStore.Windows;
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

namespace BookStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppHandler.Init(MainFrame);

            AppHandler.SwitchTo<Products>();
            VisibleProduct();
        }
        private void VisibleProduct()
        {
            BackBtn.Visibility = Visibility.Collapsed;
            OrderBtn.Visibility = Visibility.Collapsed;
            OrdersBtn.Visibility = Visibility.Visible;
            CartBtn.Visibility = Visibility.Visible;
        }
        private void VisibleOrders()
        {
            OrderBtn.Visibility = Visibility.Collapsed;
            OrdersBtn.Visibility = Visibility.Collapsed;
            CartBtn.Visibility = Visibility.Collapsed;
            BackBtn.Visibility = Visibility.Visible;
        }
        private void VisibleCart()
        {
            OrdersBtn.Visibility = Visibility.Collapsed;
            CartBtn.Visibility = Visibility.Collapsed;
            BackBtn.Visibility = Visibility.Visible;
            OrderBtn.Visibility = AppHandler.Cart.CurrentOrder.OrderProduct.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AppHandler.SwitchTo<Products>();
            VisibleProduct();
        }
        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            AppHandler.SwitchTo<Orders>();
            VisibleOrders();
        }
        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            AppHandler.SwitchTo<Cart>();
            VisibleCart();
        }
        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            AppHandler.Cart.Order();
            BackBtn_Click(sender, e);
        }
    }
}
