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
        public MainWindow()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow { Owner = this };
            addWindow.Show();
        }
        private void Modify(object sender, RoutedEventArgs e)
        {
            teacher selected = (teacher)DataGrid.SelectedItem;
            if (selected == null)
                return;

            ModifyWindow modifyWindow = new ModifyWindow { Owner = this };
            modifyWindow.Load(selected);
            modifyWindow.Show();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            teacher selected = (teacher)DataGrid.SelectedItem;
            if (selected == null)
                return;

            var result = MessageBox.Show("Вы уверены, что хотите удалить элемент базы данных?", "Окно потверждения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ApplicationContextDB.Delete(selected);
                UpdateTable();
            }
        }

        public int GetTeachersCount => DataGrid.Items.Count;
        public void UpdateTable()
        {
            DataGrid.ItemsSource = ApplicationContextDB.GetTeachers();
        }

    }
}
