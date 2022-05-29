using WebApp.Entities;

namespace WebApp.Models
{
    public class ProductModelCounted
    {
        public string name { get; set; } = "ПростоеИмя";
        public string description { get; set; } = "";
        public float price { get; set; }
        public int count { get; set; }
        public string photo_url { get; set; } = "https://km-doma.ru/assets/gallery_thumbnails/31/319484a4bb725e4eacab62c7f0c7f1ed.jpg";

        public ProductModelCounted(string name, string description, float price, string photo_url, int count)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.count = count;
            this.photo_url = photo_url;
        }
    }
}

/*
{
  "name": "Пицца Пеперонни",
  "description": "Сочная, нежная начинка, покрытая наслаждением от колбасы боварского качества",
  "price": 100,
  "photo_url": "нету"
}
 */
