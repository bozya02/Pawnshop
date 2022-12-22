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
using System.Windows.Shapes;
using Pawnshop.Pages;

namespace Pawnshop
{
    /// <summary>
    /// Interaction logic for PawnshopWindow.xaml
    /// </summary>
    public partial class PawnshopWindow : Window
    {
        public PawnshopWindow()
        {
            InitializeComponent();

            frame.NavigationService.Navigate(new ContractsListPage());

            frame.Navigated += Frame_Navigated;
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            tbTitle.Text = (frame.Content as Page).Title;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack)
                frame.GoBack();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoForward)
                frame.GoForward();
        }

        private void btnContracts_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new ContractsListPage());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new ClientsListPage());
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new ProductsListPage());
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new StatisticsPage());
        }
    }
}
