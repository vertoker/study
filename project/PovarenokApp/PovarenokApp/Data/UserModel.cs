using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PovarenokApp.Data.Enum;

namespace PovarenokApp.Data
{
    struct UserModel
    {
        public string FirstName, LastName;
        public string Login, Password;
        public Role Role;

        public static UserModel Empty = new UserModel()
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Login = string.Empty,
            Password = string.Empty,
            Role = Role.NotUser
        };

        public static UserModel SuperUser = new UserModel()
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Login = string.Empty,
            Password = string.Empty,
            Role = Role.Admin
        };
    }
}
