using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly List<ProductEntity> _store = new List<ProductEntity>();

        [Route(nameof(GetProducts))]
        public List<ProductEntity> GetProducts()
        {
            return _store;
        }

        [Route(nameof(GetProduct))]
        public ProductEntity GetProduct(int index)
        {
            return _store[index];
        }

        [Route(nameof(AddProduct))]
        public void AddProduct(string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            ProductEntity product = new ProductEntity()
            {
                ID = _store.Count + 1,
                Name = name,
                Description = description,
                Price = price,
                PhotoURL = photoURL
            };
            _store.Add(product);
        }

        [Route(nameof(UpdateProduct))]
        public void UpdateProduct(int index, string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            _store[index].Name = name;
            _store[index].Description = description;
            _store[index].Price = price;
            _store[index].PhotoURL = photoURL;
        }

        [Route(nameof(DeleteProduct))]
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
