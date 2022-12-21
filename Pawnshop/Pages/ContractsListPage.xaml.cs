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
    /// Interaction logic for ContractsListPage.xaml
    /// </summary>
    public partial class ContractsListPage : Page
    {
        public List<Contract> Contracts { get; set; }

        public ContractsListPage()
        {
            InitializeComponent();

            Contracts = DataAccess.GetContracts();
            DataAccess.NewItemAddedEvent += DataAccess_NewItemAddedEvent;

            DataContext = this;
        }

        private void DataAccess_NewItemAddedEvent()
        {
            Contracts = DataAccess.GetContracts();
            lvContracts.ItemsSource = Contracts;
            lvContracts.Items.Refresh();
        }

        private void btnNewContract_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ContractPage(new Contract(), true));
        }

        private void lvContracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var contract = lvContracts.SelectedItem as Contract;
            if (contract != null)
                NavigationService.Navigate(new ContractPage(contract));

            lvContracts.SelectedIndex = -1;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
