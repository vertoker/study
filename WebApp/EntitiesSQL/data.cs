using System.Collections.Generic;

namespace WebApp.Entities
{
    public class data
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public int CounterOrder { get; set; } = 0;
        public int CounterProduct { get; set; } = 0;
        public int CounterUser { get; set; } = 0;
    }
}