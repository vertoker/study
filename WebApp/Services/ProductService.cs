using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Models;
using WebApp.Interfaces;
using System.Linq;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private static List<product> _store = new List<product>();
        private static int counterID = 0;

        public void InitDB()
        {
            _store = ApplicationContextDB.GetProducts(ref counterID);
        }
        public List<ProductModel> GetProducts()
        {
            var result = new List<ProductModel>();
            foreach (var item in _store)
            {
                result.Add(new ProductModel(item.name, item.description, item.price, item.photo_url));
            }
            return result;
        }

        public ProductModel GetProduct(int id)
        {
            var product = _store.FirstOrDefault(item => item.id == id);
            return new ProductModel(product.name, product.description, product.price, product.photo_url);
        }
        public product GetProductData(int id)
        {
            return _store.FirstOrDefault(item => item.id == id);
        }

        public void AddProduct(string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            counterID++;
            product product = new product()
            {
                id = counterID,
                name = name,
                description = description,
                price = price,
                photo_url = photoURL
            };
            _store.Add(product);

            ApplicationContextDB.UpdateProducts(_store, counterID);
        }

        public void UpdateProduct(int id, string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);
            var entity = GetProduct(id);

            entity.name = name;
            entity.description = description;
            entity.price = price;
            entity.photo_url = photoURL;

            ApplicationContextDB.UpdateProducts(_store, counterID);
        }
        public void UpdateProduct(int id, product entity, string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            entity.name = name;
            entity.description = description;
            entity.price = price;
            entity.photo_url = photoURL;

            ApplicationContextDB.UpdateProducts(_store, counterID);
        }

        public void DeleteProduct(int id)
        {
            var entity = GetProductData(id);
            _store.Remove(entity);

            ApplicationContextDB.UpdateProducts(_store, counterID);
        }
        public void DeleteProduct(int id, product entity)
        {
            _store.Remove(entity);

            ApplicationContextDB.UpdateProducts(_store, counterID);
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
