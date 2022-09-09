using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarenokApp.DataBase;

namespace PovarenokApp.Data
{
    static class AuthHolder
    {
        public static UserModel ActiveUser { get; private set; } = UserModel.Empty;

        public static bool Auth(string login, string password)
        {
            ActiveUser = UserModel.SuperUser;
            return true;
        }
    }
}
