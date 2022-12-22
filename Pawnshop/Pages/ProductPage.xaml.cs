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
using Pawnshop.DB;

namespace Pawnshop.Pages
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public Product Product { get; set; }

        public ProductPage(Product product)
        {
            InitializeComponent();

            Product = product;
            Title = $"{Title} {Product.ToString()}";

            if (Product.Contract.ExpireDate > DateTime.Now)
            {
                IsEnabled = false;
            }

            DataContext = Product;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Product.Name))
                stringBuilder.AppendLine("Введено некорректное название!");
            if (Product.Price <= 0)
                stringBuilder.AppendLine("Укажите корректную цену!");


            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                DataAccess.SaveProduct(Product);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product.IsSold = true;
                Product.SoldDate = DateTime.Now;
                DataAccess.SaveProduct(Product);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }
    }
}
