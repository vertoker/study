using System.Collections.Generic;

namespace WebApp.Entities
{
    public class data
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public int counter_order { get; set; } = 0;
        public int counter_product { get; set; } = 0;
        public int counter_user { get; set; } = 0;
    }
}