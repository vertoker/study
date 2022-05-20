using System.ComponentModel.DataAnnotations;

namespace WebApp.Entities
{
    public class product
    {
        [Required, Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PhotoURL { get; set; }
    }
}