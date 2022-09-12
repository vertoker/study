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
        public static UserEntity ActiveUser { get; private set; }

        public static bool Auth(string login, string password)
        {
            var entity = ApplicationContextDB.Users.FirstOrDefault((UserEntity user) => { return user.login == login && user.password == password; });
            if (entity.IsEmpty())
                return false;
            ActiveUser = entity;
            return true;
        }
    }
}
