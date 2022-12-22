using Pawnshop.DB;
using Pawnshop.Services;
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

namespace Pawnshop.Pages
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public List<Product> Products { get; set; }

        public StatisticsPage()
        {
            InitializeComponent();

            Products = DataAccess.GetAllProducts();

            Statistic statistic = Finances.GetStatistic(Products, DateTime.Now.AddDays(-100), DateTime.Now);

            DataContext = statistic;
        }
    }
}
