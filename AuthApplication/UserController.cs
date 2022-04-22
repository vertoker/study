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
                user userObj = context.User.FirstOrDefault(u => u.Login == login);
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
                role roleObj = context.Role.FirstOrDefault(r => r.Id == userObj.RoleID);
                ShowMessage(string.Join(string.Empty, "Здраствуйте, ", userObj.Name, ". Вы зашли под ролью ", roleObj.RoleName, "!"));
            }
            catch (Exception)
            {
                ShowMessage("Возникла непредвиденная ошибка", MessageBoxImage.Error);
                throw;
            }
        }

        public static void Registration(string name, string role, string login, string password)
        {
            try
            {
                if (name.Length == 0)
                {
                    ShowMessage("Введите имя");
                    return;
                }
                if (role.Length == 0)
                {
                    ShowMessage("Введите свою роль");
                    return;
                }
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
                role roleObj = context.Role.FirstOrDefault(role => role.RoleName == name);
                if (roleObj == null)
                {
                    roleObj = new role()
                    {
                        RoleName = name,
                        Users = new List<user>()
                    };
                }
                user newUser = new user()
                {
                    Login = login,
                    Password = password,
                    Name = name,
                    Role = roleObj,
                    RoleID = roleObj.Id
                };
                roleObj.Users.Add(newUser);
                context.Role.Add(roleObj);
                context.User.Add(newUser);
                context.SaveChanges();

                ShowMessage(string.Join(string.Empty, "Здраствуйте, ", name, ", вы создали новую учётную запись!"));
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
