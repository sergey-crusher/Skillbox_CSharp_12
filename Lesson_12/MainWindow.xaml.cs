using Lesson_12.Interface;
using Lesson_12.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        public static ITransfer<SubAccount, SubAccount> transfer = new Transfer();
        public static string CurrentClientINN;
        public static object CurrentAccountNumber;

        public MainWindow()
        {
            if (clients == null)
            {
                clients = new Clients();
                clients.Get();
            }
            if (clients.Count > 0)
            {
                InitializeComponent();
                dgClients.ItemsSource = clients;
                dgAccounts.ItemsSource = clients.First().Accounts;
                CurrentClientINN = clients.First().INN;
            }
            clients.SaveChange();
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
                clients.SaveChange();
            }
            else
            {
                MessageBox.Show("Выберите клиента которого желаете удалить");
            }
        }

        private void dgClients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrentClientINN = ((Client)e.Row.DataContext).INN;
            clients.Update(ref clients, (Client)e.Row.DataContext, e.Column.SortMemberPath, (e.EditingElement as TextBox).Text);
            clients.SaveChange();
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CurrentClientINN = ((Client)e.AddedItems[0]).INN;
                dgAccounts.ItemsSource = ((Client)e.AddedItems[0]).Accounts;
            }
            catch
            {
                ;
            }
        }

        private void MenuAddAccount(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pAddAccount.xaml", UriKind.Relative));
        }

        private void MenuRemoveAccount(object sender, RoutedEventArgs e)
        {
            Client client;
            if (dgClients.SelectedItems.Count > 0)
            {
                client = dgClients.SelectedItems[0] as Client;
            }
            else
            {
                MessageBox.Show("Выберите клиента счёт которого желаете удалить");
                return;
            }

            if (dgAccounts.SelectedItems.Count > 0)
            {
                client.Accounts.Remove(dgAccounts.SelectedItems[0] as IAccount<Account>);
                clients.SaveChange();
            }
            else
            {
                MessageBox.Show("Выберите счёт для удаления");
            }
        }

        private void MenuReplenishBalance(object sender, RoutedEventArgs e)
        {
            if (dgAccounts.SelectedItems.Count > 0)
            {
                CurrentAccountNumber = (dgAccounts.SelectedItems[0] as Account).Number;
                NavigationService.Navigate(new Uri("pReplenishBalance.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Выберите счёт для пополнения");
            }
        }

        private void MenuTransfer(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pTransfer.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("12 модуль скилбокса", "Важная информация");
        }
    }
}
