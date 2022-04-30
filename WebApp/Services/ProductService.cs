using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Interfaces;
using System.Linq;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly static List<ProductEntity> _store = new List<ProductEntity>();
        private static int counterID = 0;

        public List<ProductEntity> GetProducts()
        {
            return _store;
        }

        public ProductEntity GetProduct(int id)
        {
            return _store.FirstOrDefault(item => item.ID == id);
        }

        public void AddProduct(string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            counterID++;
            ProductEntity product = new ProductEntity()
            {
                ID = counterID,
                Name = name,
                Description = description,
                Price = price,
                PhotoURL = photoURL
            };
            _store.Add(product);
        }

        public void UpdateProduct(int id, string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);
            var entity = GetProduct(id);

            entity.Name = name;
            entity.Description = description;
            entity.Price = price;
            entity.PhotoURL = photoURL;
        }

        public void DeleteProduct(int id)
        {
            var entity = GetProduct(id);
            _store.Remove(entity);
        }

        private static void ProductExceptionCheck(string name, float price)
        {
            if (string.IsNullOrEmpty(name))
                throw new System.Exception("Name was not received or empty");
            if (price < 0)
                throw new System.Exception("Price can't be negative");
        }
    }
}
