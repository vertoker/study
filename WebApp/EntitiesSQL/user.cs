using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Entities
{
    public class user
    {
        [Required, Key]
        public int ID { get; set; } 
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public byte UserRole { get; set; } = 0;

        public List<order> Orders { get; set; }
    }
}

public enum UserRole : byte
{
    Admin = 0,
    User = 1
}
