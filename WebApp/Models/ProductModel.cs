namespace WebApp.Models
{
    public class ProductModel
    {
        public string Name { get; set; } = "ПростоеИмя";
        public string Description { get; set; } = "";
        public float Price { get; set; }
        public string PhotoURL { get; set; } = "https://km-doma.ru/assets/gallery_thumbnails/31/319484a4bb725e4eacab62c7f0c7f1ed.jpg";
    }
}

/*
{
  "name": "Пицца Пеперонни",
  "description": "Сочная, нежная начинка, покрытая наслаждением от колбасы боварского качества",
  "price": 100,
  "photoURL": "нету"
}
 */
