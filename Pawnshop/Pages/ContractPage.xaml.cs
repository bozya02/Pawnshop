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
    /// Interaction logic for ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        public Contract Contract { get; set; }
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }

        public ContractPage(Contract contract, bool isNew = false)
        {
            InitializeComponent();

            Contract = contract;
            Clients = DataAccess.GetClients();

            Products = Contract.Products.ToList();

            if (isNew)
            {
                Title = $"Новый {Title}";
                Contract.Date = DateTime.Now;
                dgcRedeemed.Visibility = Visibility.Collapsed;
            }
            else
            {
                Title = $"{Title} {Contract.ToString()}";
                cbClient.IsEnabled = false;
                dgProducts.CanUserAddRows = false;
            }

            if (Contract.ExpireDate < DateTime.Now)
            {
                cbClient.IsEnabled = false;
                btnSave.IsEnabled = false;
                dgProducts.IsEnabled = false;
            }

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (Contract.Client == null)
                stringBuilder.AppendLine("Необходимо выбрать клиента!");
            if (Products.Count == 0)
                stringBuilder.AppendLine("Необходимо добавить товары!");


            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                foreach(var product in Products)
                {
                    if (!Contract.Products.Any(x => x.Id == product.Id))
                        Contract.Products.Add(product);

                    if (product.IsRedeemed)
                        product.RedeemedDate = DateTime.Now;
                }
                DataAccess.SaveContract(Contract);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пока не алё");
        }

        private void dgProducts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (this.dgProducts.SelectedItem != null)
            {
                (sender as DataGrid).RowEditEnding -= dgProducts_RowEditEnding;
                (sender as DataGrid).CommitEdit();
                (sender as DataGrid).Items.Refresh();

                (sender as DataGrid).RowEditEnding += dgProducts_RowEditEnding;
            }
        }
    }
}
