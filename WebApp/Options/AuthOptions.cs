using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApp.Options
{
    public class AuthOptions
    {
        public const string ISSUER = "ShopServer"; // издатель токена
        public const string AUDIENCE = "Client"; // потребитель токена
        const string KEY = "ultimatesupersecretkeyforslaves";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
