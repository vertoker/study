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

using PovarenokApp.Data.Enum;
using PovarenokApp.Scripts;
using PovarenokApp.Pages;

namespace PovarenokApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow main;

        private static int activeID = 0;
        private static Page[] pages = new Page[]
        {
            new Pages.AuthPage(),
            new Pages.ProductsPage(),
            new Pages.ProductPage(),
            new Pages.CartPage()
        };

        public static void OpenPage(int id)
        {
            (pages[activeID] as IPage).Disable();
            activeID = id;
            main.FrameMain.Navigate(pages[id]);
            main.HeaderText.Text = pages[id].Title;
            main.RoleName.Text = AuthHolder.ActiveUser == null ? string.Empty : GetRoleStatus((Role)AuthHolder.ActiveUser.UserRole);
            (pages[activeID] as IPage).Enable();
        }

        public MainWindow()
        {
            InitializeComponent();
            main = this;
            OpenPage(0);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameMain.CanGoBack)
                FrameMain.GoBack();
        }

        private static string GetRoleStatus(Role role)
        {
            switch (role)
            {
                case Role.Client: return "Роль: Клиент";
                case Role.Manager: return "Роль: Манаждер";
                case Role.Admin: return "Роль: Администратор";
                default: return "";
            }
        }
    }
}
