using Lesson_12.Interface;
using Lesson_12.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lesson_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        /// <summary>
        /// Экземпляр для работы с клиентами
        /// </summary>
        public static Clients? clients;
        public MainWindow()
        {
            if (clients == null)
            {
                clients = new Clients();
                clients.Add("Артур Вячеславович Михеев", "2", "79000000001");
                clients.First().Accounts = new ObservableCollection<IAccount<Account>>();

                clients.AddAccount<Deposit>("2", new Deposit(12, 50));
                clients.AddAccount<NonDeposit>("2", new NonDeposit(666, 600));

                //ITransfer<SubAccount, SubAccount> transfer = new Transfer();
                //transfer.Post((Account)clients.First().Accounts.First(), (Account)clients.First().Accounts.Last(), 100);
            }
            if (clients.Count > 0)
            {
                InitializeComponent();
                dgClients.ItemsSource = clients;
                dgAccounts.ItemsSource = clients.First().Accounts;
            }
        }

        private void MenuAddClient(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pAddClient.xaml", UriKind.Relative));
        }

        private void MenuRemoveClient(object sender, RoutedEventArgs e)
        {
            if (dgClients.SelectedItems.Count > 0)
            {
                Client client = dgClients.SelectedItems[0] as Client;
                clients.Remove(client.INN);
            }
            else
            {
                MessageBox.Show("Выберите клиента которого желаете удалить");
            }
        }

        private void dgClients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //clients.Update((Client)e.Row.DataContext);
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgAccounts.ItemsSource = ((Client)e.AddedItems[0]).Accounts;
        }
    }
}
