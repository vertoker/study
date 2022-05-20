using System.Collections.Generic;
using WebApp.Entities;

namespace WebApp.Interfaces
{
    public interface IProductService
    {
        void InitDB();
        void AddProduct(string name, string description, float price, string photoURL);
        void UpdateProduct(int id, string name, string description, float price, string photoURL);
        void UpdateProduct(int id, ProductEntity entity, string name, string description, float price, string photoURL);
        ProductEntity GetProduct(int id);
        List<ProductEntity> GetProducts();
        void DeleteProduct(int id);
        void DeleteProduct(int id, ProductEntity entity);
    }
}
