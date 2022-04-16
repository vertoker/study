namespace WebApp.Interfaces
{
    public interface IProductService
    {
        void AddProduct(string name, string description, float price, string photoURL);
    }
}
