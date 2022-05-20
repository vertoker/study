namespace WebApp.Entities
{
    public class ProductEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PhotoURL { get; set; }
    }
}