using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarenokApp.DataBase
{
    struct User
    {
        public string FirstName, LastName;
        public string Login, Password;
        public Role Role;

        public static User Empty = new User()
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Login = string.Empty,
            Password = string.Empty,
            Role = Role.NotUser
        };

        public static User SuperUser = new User()
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Login = string.Empty,
            Password = string.Empty,
            Role = Role.Admin
        };
    }
}
