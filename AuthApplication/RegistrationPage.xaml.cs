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

namespace AuthApplication
{
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string name = nameInput.Text;
            string role = roleInput.Text;
            string login = loginInput.Text;
            string password = passwordInput.Text;
            UserController.Registration(name, role, login, password);
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SwitchActivePage(0);
        }
    }
}
