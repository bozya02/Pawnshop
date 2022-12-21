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
                Title = $"Новый {Title}";
            else
                Title = $"{Title} {Client.ToString()}";

            DataContext = this;
        }
    }
}
