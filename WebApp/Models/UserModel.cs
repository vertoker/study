using System.Collections.Generic;

namespace WebApp.Models
{
    public class UserModel
    {
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public UserRole Role { get; set; } = UserRole.Admin;
    }
}

public enum UserRole : byte
{
    Admin = 0,
    User = 1
}
