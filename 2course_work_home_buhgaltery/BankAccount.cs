using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [JsonProperty]
        public List<ITransaction> Transactions { get; set; }

        public void AddTransaction(ITransaction transaction)
        {
            if (transaction.Category == "")
                Balance += transaction.Amount;
            else
                Balance -= transaction.Amount;

            Transactions.Add(transaction);
        }
        public BankAccount(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
