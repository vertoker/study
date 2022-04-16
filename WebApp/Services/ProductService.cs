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
        public ProductEntity GetProduct(int index)
        {
            return _store.FirstOrDefault(item => item.ID == index);
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
        public void UpdateProduct(int index, string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            _store[index].Name = name;
            _store[index].Description = description;
            _store[index].Price = price;
            _store[index].PhotoURL = photoURL;
        }
        public void DeleteProduct(int index)
        {
            _store.RemoveAt(index);
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
