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
    public partial class ModifyWindow : Window
    {
        private readonly List<role> roles;
        teacher _teacher;

        public ModifyWindow()
        {
            InitializeComponent();
            roles = ApplicationContextDB.GetRoles();
            RoleComboBox.ItemsSource = roles;
        }

        public void Load(teacher teacher)
        {
            _teacher = teacher;
            FullNameTextBox.Text = _teacher.FULLNAME;
            RoleComboBox.SelectedIndex = _teacher.ROLE - 1;
            DepartmentTextBox.Text = _teacher.DEPARTMENT;
            ExperienceTextBox.Text = _teacher.EXPERIENCE.ToString();
        }

        private void Modify(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Owner;
            role role = RoleComboBox.SelectedItem as role;

            if (FullNameTextBox.Text == string.Empty || role == null || DepartmentTextBox.Text == string.Empty || ExperienceTextBox.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            _teacher.FULLNAME = FullNameTextBox.Text;
            _teacher.ROLE = role != null ? role.ID : default;
            _teacher.DEPARTMENT = DepartmentTextBox.Text;
            if (int.TryParse(ExperienceTextBox.Text, out int result))
            {
                _teacher.EXPERIENCE = result;
            }
            else
            {
                MessageBox.Show("Стаж должен быть целочисленным числом");
                return;
            }

            ApplicationContextDB.Modify(_teacher);
            main.UpdateTable();
            Close();
        }
    }
}
