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
        private List<Teacher> _db = new List<Teacher>();
        public MainWindow()
        {
            InitializeComponent();

            _db.Add(new Teacher("Чураков", "Константин", "Эдуардович", "Ученик", 3, "Информационные системы"));
            _db.Add(new Teacher("Данила", "Куликов", "Михайлович", "Ученик", 3, "Информационные системы"));
            _db.Add(new Teacher("Что-то", "Где-то", "Когда-то", "Лучшая", 666, "В принципе всё"));

            DataGrid.ItemsSource = _db;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Owner = this;
            addWindow.Show();

            _db.Add(new Teacher());
        }
        private void Modify(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modify");
            DataGrid.ItemsSource = _db;
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Remove");
            DataGrid.ItemsSource = _db;
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
