using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Entities
{
    public class user
    {
        [Required, Key]
        public int id { get; set; } 
        public string login { get; set; } = "";
        public string password { get; set; } = "";
        public byte user_role { get; set; } = 0;

        public List<order> orders { get; set; }
    }
}

public enum UserRole : byte
{
    Admin = 0,
    User = 1
}
