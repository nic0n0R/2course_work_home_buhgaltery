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
        private User _user;
        private string _bankName;
        public BankAccountDetails()
        {
            InitializeComponent();
        }

        public BankAccountDetails(User user, string bankName)
        {
            InitializeComponent();
            _user = user;
            _bankName = bankName;
        }

        private void BankAccountDetails_Load(object sender, EventArgs e)
        {
            this.Text = $"Детали счёта {_bankName}";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;

            InitChart();
            AddChartData();
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

        private void AddChartData()
        {


        }   

        private List<ITransaction> getDateByDay(User user)
        {
            DateTime startOfDay = DateTime.Today; // начало дня - сегодняшняя дата
            DateTime endOfDay = startOfDay.AddDays(1).AddSeconds(-1); // конец дня - сегодняшняя дата + 1 день - 1 секунда

            return user.Transactions.Where(d => d.Date >= startOfDay && d.Date <= endOfDay).ToList();
            
        }

        private void getDateByMonth()
        {
            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // начало месяца - 1 число текущего месяца
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1); // конец месяца - 1 число следующего месяца - 1 секунда

        }

        private void getDateByYear()
        {
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1); // начало года - 1 января текущего года
            DateTime endOfYear = startOfYear.AddYears(1).AddSeconds(-1); // конец года - 1 января следующего года - 1 секунда

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) // за день
            {
                chart1.Series["PieSeries"].Points.Clear();

                var user_transaction = getDateByDay(_user);

                foreach (ITransaction transaction in user_transaction)
                {
                    chart1.Series["PieSeries"].Points.AddXY($"{transaction.Date}-{transaction.Category}", _user.Transactions.FirstOrDefault(t => t.Date == transaction.Date).Amount);
                }

            } 
            else if (comboBox1.SelectedIndex == 1) // за месяц
            {

            } 
            else if (comboBox1.SelectedIndex == 2) // за год
            {

            }
        }

        private void AddIncomeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
