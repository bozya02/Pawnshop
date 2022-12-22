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
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public Client Client { get; set; }

        public ClientPage(Client client, bool isNew = false)
        {
            InitializeComponent();

            Client = client;

            if (isNew)
            {
                Title = $"Новый {Title}";
                btnDelete.Visibility = Visibility.Collapsed;
            }
            else
                Title = $"{Title} {Client.ToString()}";

            DataContext = Client;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    DataAccess.DeleteClient(Client);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Client.LastName))
                stringBuilder.AppendLine("Фамилия обязательна для заполнения!");
            if (string.IsNullOrWhiteSpace(Client.LastName))
                stringBuilder.AppendLine("Имя обязательно для заполнения!");
            if (string.IsNullOrWhiteSpace(Client.LastName))
                stringBuilder.AppendLine("Паспорт обязателен для заполнения!");
            if (string.IsNullOrWhiteSpace(Client.LastName))
                stringBuilder.AppendLine("Телефон обязателен для заполнения!");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                DataAccess.SaveClient(Client);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        public void IsNumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }
}
