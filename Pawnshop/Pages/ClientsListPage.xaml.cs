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
    /// Interaction logic for ClientsListPage.xaml
    /// </summary>
    public partial class ClientsListPage : Page
    {
        public List<Client> Clients { get; set; }

        public ClientsListPage()
        {
            InitializeComponent();

            Clients = DataAccess.GetClients();

            DataContext = this;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnNewClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage(new Client(), true));
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var client = lvClients.SelectedItem as Client;
            if (client != null)
                NavigationService.Navigate(new ClientPage(client));

            lvClients.SelectedIndex = -1;
        }
    }
}
