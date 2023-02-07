using Lesson_12.Interface;
using Lesson_12.Models.ConvertJSON;
using Newtonsoft.Json;
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
            var load = JsonConvert.DeserializeObject<ObservableCollection<ClientJSON>>(
                File.ReadAllText("./clients_db.json"));
            // Добавляем клиентов из "базы"
            if (load.Count > 0)
            {
                foreach (var item in load)
                {
                    this.Add(new Client(item.FullName, item.INN, item.Phone, item.Accounts));
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
        /// Обновление данных клиента
        /// </summary>
        /// <param name="clients">Список клиентов</param>
        /// <param name="client">Клиент</param>
        /// <param name="field">Поле</param>
        /// <param name="value">Новое значение</param>
        public void Update(
            ref Clients clients,
            Client client, 
            string field,
            object value)
        {
            foreach (var item in typeof(Client).GetProperties())
            {
                if (item.Name == field)
                {
                    client.GetType()
                        .GetProperty(field)
                        .SetValue(client, value);
                    break;
                }
            }
        }

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

        /// <summary>
        /// Сохрание изменений
        /// </summary>
        public void SaveChange()
        {
            string serialize = JsonConvert.SerializeObject(this);
            File.WriteAllText("./clients_db.json", serialize);
        }
    }
}
