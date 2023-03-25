using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2course_work_home_buhgaltery
{
    public class Expense : ITransaction
    {
        /// <summary>
        /// Описывает расходы и реализует интерфейс ITransaction
        /// </summary>
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Expense(double amount, string category, DateTime date, string description)
        {
            Amount = amount;
            Category = category;
            Date = date;
            Description = description;
        }
    }
}
