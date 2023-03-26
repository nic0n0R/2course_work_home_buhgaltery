using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _2course_work_home_buhgaltery.Forms
{
    public partial class BankAccountDetails : Form
    {
        private string _username;
        private string _childName;
        private string _clicked_account_name;

        private bool _child_from_parent = false;
        public BankAccountDetails()
        {
            InitializeComponent();
        }

        public BankAccountDetails(string user, string account)
        {
            InitializeComponent();
            _username = user;
            _clicked_account_name = account;
        }

        public BankAccountDetails(string parent, string child, string account)
        {
            InitializeComponent();
            _username = parent;
            _childName = child;
            _child_from_parent = true;
            _clicked_account_name = account;
        }

        private void BankAccountDetails_Load(object sender, EventArgs e)
        {
            this.Text = $"Детали счёта {_clicked_account_name}";

            InitChart();

            InitDataGridView();
            FillDataGridView();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            UpdateChart();

            if (_child_from_parent)
            {
                AddTransactionButton.Visible = false;
            } else
            {
                AddTransactionButton.Visible = true;
            }

        }

        private void FillDataGridView()
        {
            dataGridView1.Rows.Clear();
            User usr;
            IAccount account;

            // если родитель смотрит аккаунт ребёнка
            if (_child_from_parent)
            {
                usr = DataManager.UserDeserialize().Find(u => u.Name == _childName);
                account = usr.Accounts.FirstOrDefault(u => u.Name == _clicked_account_name);
            }
            else
            {
                usr = DataManager.UserDeserialize().Find(u => u.Name == _username);
                account = usr.Accounts.FirstOrDefault(u => u.Name == _clicked_account_name);
            }

            if (account != null && account.Transactions.Count == 0)
            {
                return;
            }
            foreach (ITransaction transaction in account.Transactions)
            {
                string t_type = "";
                if (transaction.GetType() == typeof(Income))
                {
                    t_type = "Приход";
                }
                else if (transaction.GetType() == typeof(Expense))
                {
                    t_type = "Расход";
                }

                dataGridView1.Rows.Add(t_type, transaction.Amount, transaction.Category, transaction.Date, transaction.Description);
            }
            dataGridView1.Refresh();

        }

        private void InitDataGridView()
        {
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn { HeaderText = "Тип", ReadOnly = true };
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn { HeaderText = "Сумма", ReadOnly = true };
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn { HeaderText = "Категория", ReadOnly = true };
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn { HeaderText = "Дата", ReadOnly = true };
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn { HeaderText = "Описание", ReadOnly = true };


            dataGridView1.Columns.AddRange(col1, col2, col3, col4, col5);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void InitChart()
        {
            // настройка типа диаграммы
            chart1.Series.Clear();
            Series series = new Series("PieSeries");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "PieLegend";
            chart1.Series.Add(series);

            // настройка легенды
            chart1.Legends.Clear();
            Legend legend = new Legend("PieLegend");
            legend.Docking = Docking.Bottom;
            chart1.Legends.Add(legend);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }


        private void UpdateChart()
        {
            // получаем выбранный период
            var selectedPeriod = comboBox1.SelectedItem.ToString();

            User user;
            IAccount account;
            if (_child_from_parent)
            {
                user = DataManager.UserDeserialize().Find(u => u.Name == _childName);
                account = user.Accounts.Find(a => a.Name == _clicked_account_name);
            } else
            {
                user = DataManager.UserDeserialize().Find(u => u.Name == _username);
                account = user.Accounts.Find(a => a.Name == _clicked_account_name);
            }
            


            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;
            switch (selectedPeriod)
            {
                case "За сегодня":
                    fromDate = fromDate.Date;
                    toDate = toDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    break;
                case "За текущий месяц":
                    fromDate = new DateTime(fromDate.Year, fromDate.Month, 1);
                    toDate = fromDate.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                    break;
                case "За текущий год":
                    fromDate = new DateTime(fromDate.Year, 1, 1);
                    toDate = new DateTime(toDate.Year, 12, 31, 23, 59, 59);
                    break;
            }

            var transactions = account.Transactions
                .Where(t => t.Date >= fromDate && t.Date <= toDate)
                .ToList();

            Dictionary<string, string> categoryToType = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string category = row.Cells[2].Value.ToString();
                    string type = row.Cells[0].Value.ToString();
                    if (!categoryToType.ContainsKey(category))
                    {
                        categoryToType[category] = type;
                    }
                }
            }

            var transactionGroups = transactions
                .GroupBy(t => new { type = categoryToType[t.Category], t.Category })
                .Select(g => new
                {
                    Type = g.Key.type,
                    Category = g.Key.Category,
                    Amount = g.Sum(t => t.Amount)
                })
                .ToList();


            chart1.Series.Clear();
            chart1.Series.Add("TransactionData");
            chart1.Series["TransactionData"].ChartType = SeriesChartType.Pie;

            foreach (var group in transactionGroups)
            {
                string label = group.Type == "Приход" ? "Приход" : group.Category;
                chart1.Series["TransactionData"].Points.AddXY(label, group.Amount);
            }

           
        }

        private void AddIncomeButton_Click(object sender, EventArgs e)
        {
            var user = DataManager.UserDeserialize().Find(u => u.Name == _username);

            var account = user.Accounts.Find(a => a.Name == _clicked_account_name);

            using (AddTransaction AT = new AddTransaction(_username, account))
            {
                if (AT.ShowDialog() == DialogResult.OK)
                {
                    FillDataGridView();
                    UpdateChart();
                }
            }
        }
    }
}
