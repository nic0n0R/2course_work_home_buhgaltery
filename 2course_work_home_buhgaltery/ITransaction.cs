using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2course_work_home_buhgaltery
{
    public interface ITransaction
    {
        /// <summary>
        /// Описывает общие свойства и методы для работы с транзакциями (доходы и расходы)
        /// </summary>
        double Amount { get; set; }
        String Category { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
    }
}
