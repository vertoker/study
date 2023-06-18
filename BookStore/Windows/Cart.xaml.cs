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
            CartGrid.Items.Clear();
            CartGrid.Items.Add(App.DB.OrderProduct.Where());
        }
        public void Close()
        {

        }
    }
}
