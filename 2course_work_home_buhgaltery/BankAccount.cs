using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2course_work_home_buhgaltery
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BankAccount : IAccount
    {
        /// <summary>
        /// Описывает дополнительный счёт и реализует интерфейс IAccount
        /// </summary>

        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public double Balance { get; private set; }

        public void Deposit(double amount)
        {

        }

        public bool Withdraw(double amount)
        {
            return false;
        }

        public void AddTransaction(ITransaction transaction)
        {

        }
        public BankAccount(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
