using System.ComponentModel.DataAnnotations;

namespace WebApp.Entities
{
    public class product
    {
        [Required, Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string photo_url { get; set; }
    }
}