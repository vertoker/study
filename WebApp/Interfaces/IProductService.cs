using System.Collections.Generic;
using WebApp.Entities;

namespace WebApp.Interfaces
{
    public interface IProductService
    {
        void InitDB();
        void AddProduct(string name, string description, float price, string photoURL);
        void UpdateProduct(int id, string name, string description, float price, string photoURL);
        void UpdateProduct(int id, product entity, string name, string description, float price, string photoURL);
        product GetProduct(int id);
        List<product> GetProducts();
        void DeleteProduct(int id);
        void DeleteProduct(int id, product entity);
    }
}
