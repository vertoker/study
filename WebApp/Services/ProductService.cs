using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Entities;
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
            _store = ApplicationContextDB.GetProducts(out counterID);
        }
        public List<product> GetProducts()
        {
            return _store;
        }

        public product GetProduct(int id)
        {
            return _store.FirstOrDefault(item => item.ID == id);
        }

        public void AddProduct(string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            counterID++;
            product product = new product()
            {
                ID = counterID,
                Name = name,
                Description = description,
                Price = price,
                PhotoURL = photoURL
            };
            _store.Add(product);

            ApplicationContextDB.UpdateProducts(_store, counterID);
        }

        public void UpdateProduct(int id, string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);
            var entity = GetProduct(id);

            entity.Name = name;
            entity.Description = description;
            entity.Price = price;
            entity.PhotoURL = photoURL;

            ApplicationContextDB.UpdateProducts(_store, counterID);
        }
        public void UpdateProduct(int id, product entity, string name, string description, float price, string photoURL)
        {
            ProductExceptionCheck(name, price);

            entity.Name = name;
            entity.Description = description;
            entity.Price = price;
            entity.PhotoURL = photoURL;

            ApplicationContextDB.UpdateProducts(_store, counterID);
        }

        public void DeleteProduct(int id)
        {
            var entity = GetProduct(id);
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
