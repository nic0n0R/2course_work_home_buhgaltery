﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2course_work_home_buhgaltery
{
    public interface IAccount
    {
        /// <summary>
        /// Описывает общие свойства и методы для работы с банковскими счетами и кошельками.
        /// </summary>
        string Name { get; set; }
        double Balance { get; }

        List<ITransaction> Transactions { get; set; }
        void AddTransaction(ITransaction transaction);
    }
}
