using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AuthApplication
{
    public class user
    {
        [Required, Key]
        public Int32 Id { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public String? Login { get; set; }
        [Required]
        public String? Password { get; set; }

        [Required]
        public Int32? RoleID { get; set; }
        [Required]
        public role? Role { get; set; }
    }
}
