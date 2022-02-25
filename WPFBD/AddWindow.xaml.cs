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
using System.Windows.Shapes;

using WPFBD.Scripts;

namespace WPFBD
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private readonly List<role> roles;

        public AddWindow()
        {
            InitializeComponent();
            roles = ApplicationContextDB.GetRoles();
            RoleComboBox.ItemsSource = roles;
            //MessageBox.Show(roles.Count.ToString());
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Owner;
            role role = RoleComboBox.SelectedItem as role;
            teacher teacher = new teacher
            {
                FULLNAME = FullNameTextBox.Text,
                ROLE = role.ID,
                DEPARTMENT = DepartmentTextBox.Text
            };
            if (int.TryParse(ExperienceTextBox.Text, out int result))
                teacher.EXPERIENCE = result;

            ApplicationContextDB.Add(teacher);
            main.UpdateTable();
            Close();
        }
    }
}
