using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PovarenokApp.Data;
using PovarenokApp.Data.Enum;

namespace PovarenokApp.Scripts
{
    static class AuthHolder
    {
        public static Users ActiveUser { get; private set; }

        public static bool Auth(string login, string password)
        {
            var entity = ApplicationContextDB.Users.FirstOrDefault((Users user) => { return user.UserLogin == login && user.UserPassword == password; });
            if (entity == null)
                return false;
            ActiveUser = entity;
            return true;
        }
    }
}
