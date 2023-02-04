using Lesson_12.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson_12.Models
{
    /// <summary>
    /// Коллекция клиентов
    /// </summary>
    public class Clients : ObservableCollection<Client>
    {
        /// <summary>
        /// Получение данных клиентов
        /// </summary>
        public void Get()
        {
            // Считываем все данные клиентов (десериализуем их)
            var load = JsonSerializer.Deserialize<ObservableCollection<Client>>(
                File.ReadAllText("./clients_db.json"));
            // Добавляем клиентов из "базы"
            if (load.Count > 0)
            {
                this.Clear();
                foreach (var item in load)
                {
                    this.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Клиенты в БД отсутствуют");
            }
        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="FullName">ФИО</param>
        /// <param name="INN">ИНН</param>
        /// <param name="Phone">Телефон</param>
        public void Add(string FullName, string INN, string Phone)
        {
            if (!FindClient(INN, false))
            {
                this.Add(new Client(FullName, INN, Phone));
            }
            else
            {
                MessageBox.Show("Клиент с таким ИНН уже существует");
            }
        }

        /// <summary>
        /// Обновление клиента
        /// </summary>
        /// <param name="client">Обновлённый экземпляр клиента</param>
        //public void Update(Client client)
        //{
        //    if (FindClient(client.INN))
        //    {
        //        this.First(x => x.INN == client.INN).Update(client.FullName, client.Phone);
        //    }
        //}

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="INN">ИНН</param>
        public void Remove(string INN)
        {
            if (FindClient(INN))
            {
                this.Remove(this.First(x => x.INN == INN));
            }
        }

        /// <summary>
        /// Добавление счёта, клиенту
        /// </summary>
        /// <typeparam name="T">Тип счёта</typeparam>
        /// <param name="INN">ИНН</param>
        /// <param name="account">Данные счёта</param>
        public void AddAccount<T>(string INN, T account) where T : Account
        {
            if (FindClient(INN))
            {
                this.First(x => x.INN == INN).AddAccount<T>(account);
            }
        }

        /// <summary>
        /// Поиск клиента по ИНН
        /// </summary>
        /// <param name="INN">ИНН</param>
        /// <returns>true - если клиент существует</returns>
        private bool FindClient(string INN, bool MessageShow = true)
        {
            if (this.Count(x => x.INN == INN) > 0)
            {
                return true;
            }
            else
            {
                if (MessageShow)
                {
                    MessageBox.Show($"Клиент с ИНН: \"{INN}\" не найден!");
                }
                return false;
            }
        }
    }
}
