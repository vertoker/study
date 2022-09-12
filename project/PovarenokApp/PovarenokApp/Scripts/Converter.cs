using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PovarenokApp.Data;
using PovarenokApp.Data.Enum;

namespace PovarenokApp.Scripts
{
    static class Converter
    {
        public static Role GetRole(string roleName)
        {
            switch (roleName.ToLower())
            {
                case "клиент": return Role.Client;
                case "менеджер": return Role.Client;
                case "администратор": return Role.Client;
            }
            return Role.NotUser;
        }

        public static ProductType GetProductType(string productType)
        {
            switch (productType.ToLower())
            {
                case "вилки": return ProductType.Fork;
                case "ложки": return ProductType.Spoon;
                case "наборы": return ProductType.Set;
            }
            return ProductType.Empty;
        }
    }
}
