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

using WPFBD.Scripts;

namespace WPFBD
{
    public partial class MainWindow : Window
    {
        //private List<teacher> _db = new List<teacher>();
        public MainWindow()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Owner = this;
            addWindow.Show();
        }
        private void Modify(object sender, RoutedEventArgs e)
        {
            ModifyWindow modifyWindow = new ModifyWindow();
            modifyWindow.Owner = this;
            modifyWindow.Show();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Remove");
        }

        private void UpdateTable()
        {
            DataGrid.ItemsSource = ApplicationContextDB.GetDatabase();
        }

        private void Lab5()
        {
            List<Phone> db = new List<Phone>();

            db.Add(new Phone("Iphone 6S", "Apple", 54990));
            db.Add(new Phone("Lumia 950", "Microsoft", 39990));

            DataGrid.ItemsSource = db;
        }

    }
}
