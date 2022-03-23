using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ClientAuthorization_Чураков
{
    internal class role
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public String? RoleName { get; set; }
        [Required]
        public List<user>? Users { get; set; }
    }
}
