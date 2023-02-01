using Lesson_12.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson_12.Models
{
    /// <summary>
    /// Класс для работы с клиентами
    /// </summary>
    public class Client : ViewModelBase
    {
        #region Свойства 
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    RaisePropertyChanged("FullName");
                }
            }
        }
        private string fullName;
        /// <summary>
        /// ИНН
        /// </summary>
        public string INN
        {
            get
            {
                return inn;
            }
            set
            {
                if (inn != value)
                {
                    inn = value;
                    RaisePropertyChanged("INN");
                }
            }
        }
        private string inn;
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    RaisePropertyChanged("Phone");
                }
            }
        }
        private string phone;
        /// <summary>
        /// Список счетов клиента
        /// </summary>
        public ObservableCollection<IAccount<Account>> Accounts { get; set; }
        #endregion

        #region Конструкторы
        public Client(string FullName, string INN, string Phone)
        {
            if (String.IsNullOrEmpty(FullName) || String.IsNullOrEmpty(INN) || String.IsNullOrEmpty(Phone))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                this.FullName = FullName;
                this.INN = INN;
                this.Phone = Phone;
            }
        }
        #endregion

        /// <summary>
        /// Обновление данных клиента
        /// </summary>
        /// <param name="FullName">ФИО</param>
        /// <param name="Phone">Телефон</param>
        public void Update(string FullName, string Phone)
        {
            this.FullName = FullName;
            this.Phone = Phone;
        }
        
        /// <summary>
        /// Добавление счёта
        /// </summary>
        /// <typeparam name="T">Тип счёта</typeparam>
        /// <param name="account">Данные счёта</param>
        public void AddAccount<T>(T account) where T : Account
        {            
            this.Accounts.Add((IAccount<Account>)account);
        }
    }
}
