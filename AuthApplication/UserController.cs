using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AuthApplication
{
    public static class UserController
    {
        public static UserHolder? UserHolder { get; private set; }

        public static void Login(string login, string password)
        {
            try
            {
                if (login.Length == 0)
                {
                    ShowMessage("Введите логин");
                    return;
                }
                if (password.Length == 0)
                {
                    ShowMessage("Введите пароль");
                    return;
                }
                ApplicationContext context = new ApplicationContext();
                user userObj = context.Users.FirstOrDefault(u => u.Login == login);
                if (userObj == null)
                {
                    ShowMessage("Такого пользователя не существует");
                    return;
                }
                if (userObj.Password != password)
                {
                    ShowMessage("Неверный пароль");
                    return;
                }
                ShowMessage(string.Join(string.Empty, "Здраствуйте, ", userObj.Name, ". Вы зашли под ролью ", userObj.Role.RoleName, "!"));
            }
            catch (Exception)
            {
                ShowMessage("Возникла непредвиденная ошибка", MessageBoxImage.Error);
                throw;
            }
        }

        private static void ShowMessage(string text, MessageBoxImage image = MessageBoxImage.Information)
        {
            MessageBox.Show(text, "Уведомление", MessageBoxButton.OK, image);
        }
    }
}
