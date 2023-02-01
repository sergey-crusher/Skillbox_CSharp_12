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
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Экземпляр для работы с клиентами
        /// </summary>
        Clients clients;
        public MainWindow()
        {
            clients = new Clients();
            clients.Add(new Client("1", "2", "3"));
            clients.First().Accounts = new ObservableCollection<IAccount<Account>>();

            clients.AddAccount<Deposit>("123", new Deposit(12,13));

            string qwe = "";
            InitializeComponent();
        }
    }
}
