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
        }

        private void btnGetStatistica_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var start = dpStart.SelectedDate;
            var end = dpEnd.SelectedDate;

            if (start == null)
                stringBuilder.AppendLine("Дата начала периода не выбрана!");
            if (end == null)
                stringBuilder.AppendLine("Дата конца периода не выбрана!");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Statistic statistic = Finances.GetStatistic(Products, (DateTime)start, (DateTime)end);

            DataContext = statistic;
        }
    }
}
