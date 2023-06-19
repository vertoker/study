using BookStore.DB;
using BookStore.Scripts;
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

namespace BookStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Page, IPage
    {
        public Cart()
        {
            InitializeComponent();
        }

        public void Open()
        {
            AppHandler.Cart.CreateCurrentOrder();
            var orderProducts = AppHandler.Cart.CurrentOrder.OrderProduct.ToList();
            CartGrid.ItemsSource = orderProducts;
        }
        public void Close()
        {

        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (ListViewItem)sender;
            if (item != null && item.IsSelected)
            {
                var orderProduct = (OrderProduct)item.DataContext;
                AppHandler.Cart.RemoveFrom(ref orderProduct);
                Open();
            }
        }
    }
}
