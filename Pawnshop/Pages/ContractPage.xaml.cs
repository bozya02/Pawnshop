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

        public ContractPage(Contract contract, bool isNew = false)
        {
            InitializeComponent();

            Contract = contract;
            Clients = DataAccess.GetClients();

            if (isNew)
            {
                Title = $"Новый {Title}";
                Contract.Date = DateTime.Now;
            }
            else
                Title = $"{Title} {Contract.ToString()}";

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (Contract.Client == null)
                stringBuilder.AppendLine("Необходимо выбрать клиента!");
            if (Contract.ContractProducts.Count == 0)
                stringBuilder.AppendLine("Необходимо добавить товары!");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                DataAccess.SaveContract(Contract);
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
    }
}
