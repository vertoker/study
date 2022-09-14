using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PovarenokApp.Data.Enum;

namespace PovarenokApp.Data
{
    public struct UserEntity
    {
        public int id;
        public string first_name, last_name, patronymic;
        public string login, password;
        public int role;

        public bool IsEmpty()
        {
            return login == null || password == null;
        }
        public bool IsAdmin()
        {
            return (Role)role == Role.Admin;
        }

        public static UserEntity Empty = new UserEntity()
        {
            id = 0,
            first_name = string.Empty,
            last_name = string.Empty,
            patronymic = string.Empty,
            login = string.Empty,
            password = string.Empty,
            role = (int)Role.NotUser
        };

        public static UserEntity SuperUser = new UserEntity()
        {
            id = 0,
            first_name = string.Empty,
            last_name = string.Empty,
            patronymic = string.Empty,
            login = string.Empty,
            password = string.Empty,
            role = (int)Role.Admin
        };
    }
}
