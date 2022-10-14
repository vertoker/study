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

using PovarenokApp.Data;
using PovarenokApp.Scripts;

namespace PovarenokApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page, IPage
    {
        private static ProductPage instance;
        private int id;

        private bool readMode;
        private bool addMode = false;

        private void SetReadOnly(bool value)
        {
            readMode = value;
            InputFieldTitle.IsReadOnly = value;
            InputFieldCost.IsReadOnly = value;
            InputFieldDiscount.IsReadOnly = value;
            InputFieldType.IsReadOnly = value;

            BtnSelectImage.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            BtnSave.Visibility = value ? Visibility.Collapsed : Visibility.Visible;

            UpdateAdminEditComboVisibility();
        }

        public void UpdateAdminEditComboVisibility()
        {
            bool value = AuthHolder.ActiveUser == null && readMode;
            BtnEdit.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            BtnDelete.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public void Enable()
        {

        }
        public void Disable()
        {

        }

        public ProductPage()
        {
            instance = this;
            InitializeComponent();
            SetReadOnly(true);
        }

        public static void LoadProduct(Products product)
        {
            instance.id = product.ProductID;
            instance.InputFieldTitle.Text = product.ProductName;
            instance.InputFieldCost.Text = product.ProductCost.ToString("0,00");
            instance.InputFieldDiscount.Text = product.ProductDiscountAmount.Value.ToString();
            instance.InputFieldType.Text = product.ProductCategory.ToString();

            instance.UpdateAdminEditComboVisibility();
        }

        public static void AddProduct()
        {
            instance.id = ApplicationContextDB.Counters[2].GetNext();
            instance.InputFieldTitle.Text = string.Empty;
            instance.InputFieldCost.Text = "0,00";
            instance.InputFieldDiscount.Text = "0";
            instance.InputFieldType.Text = "0";
            instance.addMode = true;

            instance.SetReadOnly(false);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            SetReadOnly(false);
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContextDB.DeleteProduct(id);
            MainWindow.OpenPage(1);
        }
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (readMode)
            {
                MainWindow.OpenPage(1);
            }
            else
            {
                SetReadOnly(true);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ErrorCheck(out string errorMessage))
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (addMode)
                {
                    ApplicationContextDB.AddProduct(id,
                        instance.InputFieldTitle.Text,
                        float.Parse(instance.InputFieldCost.Text),
                        int.Parse(instance.InputFieldDiscount.Text),
                        int.Parse(instance.InputFieldType.Text));
                    addMode = false;
                }
                else
                {
                    ApplicationContextDB.EditProduct(id,
                        instance.InputFieldTitle.Text,
                        float.Parse(instance.InputFieldCost.Text),
                        int.Parse(instance.InputFieldDiscount.Text),
                        int.Parse(instance.InputFieldType.Text));
                }
                SetReadOnly(true);
            }
        }

        private bool ErrorCheck(out string errorMessage)
        {
            bool error = false;
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrEmpty(InputFieldTitle.Text))
                errorBuilder.AppendLine("Укажите название\n");

            /*var checkTitle = ApplicationContextDB.Products.FirstOrDefault(p => p.title.ToLower() == InputFieldTitle.Text);
            if (!checkTitle.IsEmpty())
                errorBuilder.AppendLine("Такой товар уже есть в базе данных\n");*/

            decimal cost = 0;
            if (!decimal.TryParse(InputFieldCost.Text, out cost) || cost <= 0)
                errorBuilder.AppendLine("Стоимость товара должна быть положительным числом\n");

            if (!string.IsNullOrEmpty(InputFieldDiscount.Text))
            {
                int discount = 0;
                if (!int.TryParse(InputFieldDiscount.Text, out discount) || discount < 0 || discount > 100)
                    errorBuilder.AppendLine("Размер скидки - целое число в диапозоне от 0 до 100%\n");
            }

            error = errorBuilder.Length > 0;
            if (error)
                errorBuilder.Insert(0, "Устраните следующие ошибки: \n");

            errorMessage = errorBuilder.ToString();
            return error;
        }
    }
}
