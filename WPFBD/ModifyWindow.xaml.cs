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
        teacher _teacher;
        public ModifyWindow()
        {
            InitializeComponent();

            _teacher = ApplicationContextDB.Get(0);
            FullNameTextBox.Text = _teacher.FULLNAME;
            RoleNameTextBox.Text = _teacher.ROLEOBJECT.ROLENAME;
            DepartmentTextBox.Text = _teacher.DEPARTMENT;
            ExperienceTextBox.Text = _teacher.EXPERIENCE.ToString();
        }

        private void Modify(object sender, RoutedEventArgs e)
        {
            _teacher.FULLNAME = FullNameTextBox.Text;
            _teacher.SetRole(RoleNameTextBox.Text);
            _teacher.DEPARTMENT = DepartmentTextBox.Text;
            _teacher.EXPERIENCE = int.Parse(ExperienceTextBox.Text);

            ApplicationContextDB.Set(_teacher);
            Close();
        }
    }
}
