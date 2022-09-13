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
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();

            LViewServices.ItemsSource = ApplicationContextDB.Products;
            LViewServices.
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEditProductPage.EditProduct((ProductEntity)LViewServices.SelectedItem);
            MainWindow.OpenPage(2);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateSelection()
        {

        }

        private Visibility AdminButtonsVisibility
        {
            get
            {
                return LViewServices.SelectedIndex != -1 ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
