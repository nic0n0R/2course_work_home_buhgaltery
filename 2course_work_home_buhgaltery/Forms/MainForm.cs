using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _2course_work_home_buhgaltery.Forms
{
    public partial class MainForm : Form
    {
        private string _username;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string user)
        {
            InitializeComponent();
            _username = user;

            userNameLabel.Text = _username;

            RoleLabel.Text = DataManager.UserDeserialize().Find(u => u.Name == _username).Role.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Если родительский аккаунт, то добавляем вкладки для просмотра инфы о всех счетах детей
            if (DataManager.UserDeserialize().Find(u => u.Name == _username).Role == UserRole.Parent)
                AddChildAccountView();

            // инциализация датагрид вью. Настройка колонок
            InitDataGridView(dgvMain);
            tabControl1.TabPages[0].Text = userNameLabel.Text;

            FillDataGridView(dgvMain, _username);
        }

        private void InitDataGridView(DataGridView dgv)
        {
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn { HeaderText = "Название счёта", ReadOnly = true };
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn { HeaderText = "Баланс", ReadOnly = true };
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn { HeaderText = "Последняя транзакция", ReadOnly = true };
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn { HeaderText = "Всего транзакций", ReadOnly = true };
            DataGridViewButtonColumn col5 = new DataGridViewButtonColumn { HeaderText = "Подробности", Text = "Подробнее", UseColumnTextForButtonValue = true };


            dgv.Columns.AddRange(col1, col2, col3, col4, col5);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgv.CellClick += DataGridView_CellClick;
        }

        private DataGridView getDataGridViewFromTabPage(TabPage tabPage)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    return dataGridView;
                }
            }
            return null;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = getDataGridViewFromTabPage(tabControl1.SelectedTab);

            if (e.ColumnIndex == 4 && e.RowIndex >= 0 && e.RowIndex != dgv.Rows.Count - 1)
            {
                string bankName = dgv[0, e.RowIndex].Value.ToString();
                string clicked_account_name = "";
                BankAccountDetails BAD;
                // если родитель пытается зайти в свой счёт
                if (RoleLabel.Text == "Parent" && tabControl1.SelectedTab.Text == _username)
                {
                    clicked_account_name = DataManager.UserDeserialize()
                    .Find(a => a.Name == _username).Accounts
                    .Find(c => c.Name == bankName).Name;
                    BAD = new BankAccountDetails(tabControl1.SelectedTab.Text, clicked_account_name);
                }
                // Если родитель пытается зайти в детский счёт
                else if (RoleLabel.Text == "Parent" && tabControl1.SelectedTab.Text != _username)
                {
                    clicked_account_name = DataManager.UserDeserialize()
                   .Find(a => a.Name == tabControl1.SelectedTab.Text).Accounts
                   .Find(c => c.Name == bankName).Name;
                    BAD = new BankAccountDetails(_username, tabControl1.SelectedTab.Text, clicked_account_name);
                }
                // Если ребёнок пытается войти в свой аккаунт
                else
                {
                    clicked_account_name = DataManager.UserDeserialize()
                    .Find(a => a.Name == _username).Accounts
                    .Find(c => c.Name == bankName).Name;
                    BAD = new BankAccountDetails(tabControl1.SelectedTab.Text, clicked_account_name);
                }

                BAD.ShowDialog();
                FillDataGridView(dgv, tabControl1.SelectedTab.Text);
            }
        }


        private void FillDataGridView(DataGridView dgv, string user)
        {
            // очищаем предыдущие записи, если таковые имеются
            dgv.Rows.Clear();
            // Заполнение данных об основном счёте
            FillWallet(dgv, user);
            // Заполнение данных о дополнительных счетах
            FillBankAccounts(dgv, user);
        }

        private void FillWallet(DataGridView dgv, string userName)
        {
            var date = DateTime.MinValue;
            var usr = DataManager.UserDeserialize().First(u => u.Name == userName);
            // Если ещё транзакций нет

            if (usr.Accounts[0].Transactions.Count != 0)
            {
                date = usr.Accounts[0].Transactions[0].Date;
            }
            dgv.Rows.Add(usr.Accounts[0].Name, usr.Accounts[0].Balance, date, usr.Accounts[0].Transactions.Count);

        }

        private void FillBankAccounts(DataGridView dgv, string userName)
        {
            var date = DateTime.MinValue;

            var usr = DataManager.UserDeserialize().Find(u => u.Name == userName);

            for (int i = 1; i < usr.Accounts.Count; i++)
            {
                if (usr.Accounts[i].Transactions.Count != 0)
                {
                    date = usr.Accounts[i].Transactions[usr.Accounts[i].Transactions.Count - 1].Date;
                }
                dgv.Rows.Add(usr.Accounts[i].Name, usr.Accounts[i].Balance, date, usr.Accounts[i].Transactions.Count);
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
                dgv.Location = new Point(6, 6);
                dgv.Size = new Size(806, 405);

                InitDataGridView(dgv);
                FillDataGridView(dgv, child.Name);

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

            var user = DataManager.UserDeserialize().Find(u => u.Name == _username);

            if (user.Accounts.Find(a => a.Name == bankAccountName) != null)
            {
                MessageBox.Show("Уже существует счёт с таким именем!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newBankAccount = new BankAccount(bankAccountName, 0.0);
            newBankAccount.Transactions = new List<ITransaction>();


            user.AddAccount(newBankAccount);

            // сохраняем данные о новом созданном счёте
            DataManager.UserSerialize(user);

            FillDataGridView(dgvMain, _username);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                CreateBankAccountButton.Visible = false;
            }
            else
            {
                CreateBankAccountButton.Visible = true;
            }
        }
    }
}
