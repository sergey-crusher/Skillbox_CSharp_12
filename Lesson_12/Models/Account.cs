using Lesson_12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_12.Models
{
    /// <summary>
    /// Родительский класс для работы со счетами клиентов
    /// </summary>
    public class Account : ViewModelBase
    {
        #region Свойства
        /// <summary>
        /// Номер счёта
        /// </summary>
        public object Number
        {
            get
            {
                return number;
            }
            set
            {
                if (number != value)
                {
                    number = value;
                    RaisePropertyChanged("Number");
                }
            }
        }
        private object number;

        /// <summary>
        /// Остаток на счёте
        /// </summary>
        public object Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (balance != value)
                {
                    balance = value;
                    RaisePropertyChanged("Balance");
                }
            }
        }
        private object balance;
        #endregion

        #region Конструкторы
        public Account(object number, object balance)
        {
            Number = number;
            Balance = new Balance<object>(balance).Value;
        }

        public Deposit GetValue()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
