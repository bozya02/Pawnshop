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

        public ContractPage(Contract contract, bool isNew = false)
        {
            InitializeComponent();

            Contract = contract;

            if (isNew)
                Title = $"Новый {Title}";
            else
                Title = $"{Title} {Contract.ToString()}";

            DataContext = this;
        }
    }
}
