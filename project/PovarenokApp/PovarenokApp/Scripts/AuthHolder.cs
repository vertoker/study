using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarenokApp.DataBase;

namespace PovarenokApp.Scripts
{
    static class AuthHolder
    {
        public static User ActiveUser { get; private set; } = User.Empty;

        public static bool Auth(string login, string password)
        {
            ActiveUser = User.SuperUser;
            return true;
        }
    }
}
