using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2course_work_home_buhgaltery.Forms
{
    public partial class AddTransaction : Form
    {
        private string _username;
        private IAccount _account;

        public AddTransaction()
        {
            InitializeComponent();
        }

        public AddTransaction(string user, IAccount account)
        {
            InitializeComponent();
            _username = user;
            _account = account;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // если приход
            if (transactionTypeComboBox.SelectedIndex == 0)
            {
                categoryLabel.Visible = false;
                categoryComboBox.Visible = false;
                warningCatLabel.Visible = false;
            }
            // если расход
            else if (transactionTypeComboBox.SelectedIndex == 1)
            {
                categoryLabel.Visible = true;
                categoryComboBox.Visible = true;
                if (DataManager.CategoriesDeserialize().Count == 0)
                    warningCatLabel.Visible = true;


                foreach (string category in DataManager.CategoriesDeserialize())
                    categoryComboBox.Items.Add(category);
            }
        }

        private void SumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // проверка на то, что нельзя ввводить ничего кроме цифр и клавиш удаления
            // \b - backspace
            // \u007F - клавиша Delete
            if (!Char.IsDigit(ch) && ch != '\b' && ch != '\u007F')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(addCategoryTextBox.Text) || addCategoryTextBox.Text == String.Empty)
            {
                MessageBox.Show("Не заполнено поле с названием категории.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataManager.CategoriesSerialize(addCategoryTextBox.Text);

            MessageBox.Show("Категория была добавлена.");
            addCategoryTextBox.Text = "";

            categoryComboBox.Items.Clear();
            foreach (string category in DataManager.CategoriesDeserialize())
            {
                categoryComboBox.Items.Add(category);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataManager.CategoriesDeserialize().Count == 0 && categoryComboBox.Visible)
            {
                MessageBox.Show("Категорий нет. Сначала добавьте хоть одну.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (SumTextBox.Text == String.Empty)
            {
                MessageBox.Show("Не заполнено поле с суммой.");
                return;
            }

            if (categoryComboBox.SelectedIndex == -1 && categoryComboBox.Visible)
            {
                MessageBox.Show("Не выбрана категория.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var transactionType = transactionTypeComboBox.SelectedItem.ToString();
            var sum = Convert.ToDouble(SumTextBox.Text);

            var description = DescriptionTextBox.Text;


            var user = DataManager.UserDeserialize().FirstOrDefault(u => u.Name == _username);

            if (user != null)
            {
                var account = user.Accounts.FirstOrDefault(a => a.Name == _account.Name);

                if (account != null)
                {
                    if (transactionType == "Приход")
                    {
                        account.AddTransaction(new Income(sum, "", DateTime.Now, description));
                    }
                    else if (transactionType == "Расход")
                    {
                        var category = categoryComboBox.SelectedItem.ToString();
                        account.AddTransaction(new Expense(sum, category, DateTime.Now, description));
                    }
                }
            }

            DataManager.UserSerialize(user);

            DialogResult = DialogResult.OK;
        }

        private void AddTransaction_Load(object sender, EventArgs e)
        {
            transactionTypeComboBox.SelectedIndex = 0;
            warningCatLabel.Visible = false;

            transactionTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }
    }
}
