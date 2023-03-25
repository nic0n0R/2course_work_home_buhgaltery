using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2course_work_home_buhgaltery
{
    public class User
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }
        
        public string Password { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<ITransaction> Transactions { get; set; }

        public User(string name, UserRole role)
        {
            Name = name;
            Role = role;
            Accounts = new List<IAccount>();
            Transactions = new List<ITransaction>();
        }

        public void AddAccount(IAccount account)
        {
            Accounts.Add(account);
        }

        public void RemoveAccount(IAccount account)
        {
            Accounts.Remove(account);
        }

        public void AddTransaction(ITransaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void RemoveTransaction(ITransaction transaction)
        {
            Transactions.Remove(transaction);
        }

        public double GetTotalBalance()
        {
            double totalBalance = 0;

            foreach (var account in Accounts)
            {
                totalBalance += account.Balance;
            }

            return totalBalance;
        }
    }

}
