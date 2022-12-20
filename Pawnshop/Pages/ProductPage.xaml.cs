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
        public object Product { get; set; }

        public ProductPage(object product, bool isNew = false)
        {
            InitializeComponent();

            Product = product;

            if (isNew)
                Title = $"Новый {Title}";
            else
                Title = $"{Title} {Product.ToString()}";

            DataContext = this;
        }
    }
}
