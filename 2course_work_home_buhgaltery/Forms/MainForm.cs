using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _2course_work_home_buhgaltery.Forms
{
    public partial class MainForm : Form
    {
        private User _cur_user;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(User user)
        {
            InitializeComponent();
            _cur_user = user;

            userNameLabel.Text = _cur_user.Name;
            RoleLabel.Text = _cur_user.Role.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Если родительский аккаунт, то добавляем вкладки для просмотра инфы о всех счетах детей
            if (_cur_user.Role == UserRole.Parent)
                AddChildAccountView();

            // инциализация датагрид вью. Настройка колонок
            InitDataGridView(dataGridView1);

            FillDataGridView(dataGridView1, _cur_user);
        }

        private void InitDataGridView(DataGridView dgv)
        {
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn { HeaderText = "Название счёта", ReadOnly = true };
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn { HeaderText = "Баланс", ReadOnly = true };
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn { HeaderText = "Последняя транзакция", ReadOnly = true };
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn { HeaderText = "Всего транзакций", ReadOnly = true };
            DataGridViewButtonColumn  col5 = new DataGridViewButtonColumn { HeaderText = "Подробности", Text = "Подробнее", UseColumnTextForButtonValue = true };

            
            dgv.Columns.AddRange(col1, col2, col3, col4, col5);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgv.CellClick += DataGridView_CellClick;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                string bankName = dataGridView1[1, e.RowIndex].Value.ToString();
                BankAccountDetails BAD = new BankAccountDetails(_cur_user, bankName);
                BAD.ShowDialog();
            }
        }


        private void FillDataGridView(DataGridView dgv, User user)
        {
            // очищаем предыдущие записи, если таковые имеются
            dgv.Rows.Clear();
            // Заполнение данных об основном счёте
            FillWallet(dgv, user);
            // Заполнение данных о дополнительных счетах
            FillBankAccounts(dgv, user);
        }

        private void FillWallet(DataGridView dgv, User user)
        {
            var date = DateTime.MinValue;

            // Если ещё транзакций нет
            if (user.Transactions.Count != 0)
            {
                date = user.Transactions[user.Transactions.Count - 1].Date;
            }
            dgv.Rows.Add(user.Accounts[0].Name, user.Accounts[0].Balance, date, user.Transactions.Count);

        }

        private void FillBankAccounts(DataGridView dgv, User user)
        {
            var date = DateTime.MinValue;

            for (int i = 1; i < user.Accounts.Count; i++)
            {
                if (user.Transactions.Count != 0)
                {
                    date = user.Transactions[user.Transactions.Count - 1].Date;
                }
                dgv.Rows.Add(user.Accounts[i].Name, user.Accounts[i].Balance, date, user.Transactions.Count);
            }
        }

        private void AddChildAccountView()
        {
            TabPage newTabPage;


            string usersJson = File.ReadAllText("users.json");
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Converters = { new AccountConverter() }
            };
            List<User> users = JsonConvert.DeserializeObject<List<User>>(usersJson, settings);

            List<User> children = users.FindAll(u => u.Role == UserRole.Child);

            if (children.Count == 0)
                return;

            foreach (User child in children)
            {
                newTabPage = new TabPage();
                newTabPage.Text = child.Name;
                tabControl1.TabPages.Add(newTabPage);

                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(6,6);
                dgv.Size = new Size(806, 405);

                InitDataGridView(dgv);
                FillDataGridView(dgv, child);

                newTabPage.Controls.Add(dgv);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Show();

        }

        private void CreateBankAccountButton_Click(object sender, EventArgs e)
        {
            string bankAccountName = String.Empty;
            using (CreateBankAccount CBA = new CreateBankAccount())
            {
                if (CBA.ShowDialog() == DialogResult.OK)
                {
                    bankAccountName = CBA.newBankAccoutName;
                }
            }

            var newBankAccount = new BankAccount(bankAccountName, 0.0);
            _cur_user.AddAccount(newBankAccount);
            FillDataGridView(dataGridView1, _cur_user);
            
            // сохраняем данные о новом созданном счёте
            var users = DataManager.UserDeserialize();
            users.FirstOrDefault(u => u.Name == _cur_user.Name).AddAccount(newBankAccount);
            DataManager.UserSerialize(users);
        }
    }
}
