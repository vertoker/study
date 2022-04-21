using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace AuthApplication
{
    public class role
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public String? RoleName { get; set; }
        [Required]
        public List<user>? Users { get; set; }
    }
}
