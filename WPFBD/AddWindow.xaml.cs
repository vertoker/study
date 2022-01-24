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
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            teacher teacher = new teacher();
            teacher.FULLNAME = FullNameTextBox.Text;
            teacher.SetRole(RoleNameTextBox.Text);
            teacher.DEPARTMENT = DepartmentTextBox.Text;
            teacher.EXPERIENCE = int.Parse(ExperienceTextBox.Text);

            ApplicationContextDB.Add(teacher);
            Close();
        }
    }
}
