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
using Newtonsoft.Json;

namespace _2course_work_home_buhgaltery.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }


        private void registrateBtn_Click(object sender, EventArgs e)
        {
            string userName = nameTextBox.Text;
            string password = firstPassTextBox.Text;
            string repeatPassword = repeatPassTextBox.Text;

            List<User> users;


            users = DataManager.UserDeserialize();

            if (users.Find(u => u.Name == userName) != null)
            {
                MessageBox.Show("Пользователь с таким именем уже существует!");
                return;
            }

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatPassword))
            {
                MessageBox.Show("Не все поля заполнены.");
                return;
            }

            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            if (roleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль пользователя.");
                return;
            }

            UserRole role = (UserRole)roleComboBox.SelectedIndex;
            User newUser = new User(userName, role);
            newUser.Password = password;

            newUser.AddAccount(new Wallet($"{userName}-Главный кошелёк", 0.0));
            newUser.Accounts[0].Transactions = new List<ITransaction>();

            DataManager.UserSerialize(newUser);

            MessageBox.Show("Пользователь успешно зарегистрирован.");
            this.Close();
            Application.OpenForms[0].Show();

        }


        private void showPassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            firstPassTextBox.PasswordChar = showPassCheckBox.Checked ? '\0' : '*';
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            firstPassTextBox.PasswordChar = '*';
            wrongPasswordLabel.Visible = false;
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void repeatPassTextBox_Leave(object sender, EventArgs e)
        {
            if (firstPassTextBox.Text != repeatPassTextBox.Text)
            {
                wrongPasswordLabel.Visible = true;
            }
            else
            {
                wrongPasswordLabel.Visible = false;
            }
        }
    }
}
