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
    /// Interaction logic for ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        public List<Product> Products { get; set; }

        public ProductsListPage()
        {
            InitializeComponent();

            Products = DataAccess.GetProducts();
            DataAccess.NewItemAddedEvent += DataAccess_NewItemAddedEvent;

            DataContext = this;
        }

        private void DataAccess_NewItemAddedEvent()
        {
            Products = DataAccess.GetProducts();
            lvProducts.ItemsSource = Products;
            lvProducts.Items.Refresh();
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = lvProducts.SelectedItem as Product;
            if (product != null)
                NavigationService.Navigate(new ProductPage(product));

            lvProducts.SelectedIndex = -1;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = tbSearch.Text.ToLower();

            lvProducts.ItemsSource = Products.FindAll(c => c.Name.ToLower().Contains(searchText));
        }
    }
}
