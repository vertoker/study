using PovarenokApp.Data;
using PovarenokApp.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PovarenokApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page, IPage
    {
        private List<CartProduct> products = new List<CartProduct>();
        private static CartPage instance;

        public CartPage()
        {
            InitializeComponent();
            instance = this;
        }

        public void Enable()
        {
            UpdateCart();
        }
        public void Disable()
        {

        }

        public static void AddProduct(Products product)
        {
            AddProduct(new ProductEntity()
            {
                id = product.ProductID,
                type = product.ProductCategory,
                cost = (float)product.ProductCost,
                discount_amount = (int)product.ProductDiscountAmount,
                quantity_in_stock = product.ProductQuantityInStock,
                title = product.Title,
                image = product.ProductImage
            });
        }
        public static void AddProduct(ProductEntity product)
        {
            var index = instance.products.FindIndex((CartProduct cp) => { return cp.id == product.id; });
            if (index == -1)
            {
                if (product.quantity_in_stock > 0)
                {
                    instance.products.Add(new CartProduct() { id = product.id, quantity = 1 });
                }
                else
                {
                    MessageBox.Show("Товара на складе нету");
                }
            }
            else
            {
                if (product.quantity_in_stock > instance.products[index].quantity)
                {
                    instance.products[index].quantity++;
                }
                else
                {
                    MessageBox.Show("Товар на складе кончился");
                }
            }
        }
        public void UpdateCart()
        {
            List<Products> productEntities = new List<Products>();
            for (int i = 0; i < products.Count; i++)
            {
                var product = ApplicationContextDB.Products.FirstOrDefault((Products p) => { return p.ProductID == products[i].id; }).DeepCopy();
                if (!product.IsEmpty())
                {
                    product.ProductQuantityInStock = products[i].quantity;
                    product.ProductCost *= product.ProductQuantityInStock;
                    productEntities.Add(product);
                }
            }
            LViewServices.ItemsSource = null;
            LViewServices.ItemsSource = productEntities;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(1);
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            LViewServices.ItemsSource = null;
            ApplicationContextDB.CreateOrder(products);
            products.Clear();

            MessageBox.Show("Ваш заказ был создан!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow.OpenPage(1);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = (ProductEntity)(sender as Button).DataContext;
                products.Remove(products.Find((CartProduct p) => { return p.id == product.id; }));
                UpdateCart();
            }
            catch
            {
                var product = (Products)(sender as Button).DataContext;
                products.Remove(products.Find((CartProduct p) => { return p.id == product.ProductID; }));
                UpdateCart();
            }
        }
    }
}
