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

            List<User> users = new List<User>();


            users = DataManager.UserDeserialize();

            if (users.Any(u => u.Name == userName))
            {
                MessageBox.Show("Пользователь с таким именем уже существует!");
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

            newUser.AddAccount(new Wallet($"{userName}-wallet", 0.0));
            users.Add(newUser);

            DataManager.UserSerialize(users);

            MessageBox.Show("Пользователь успешно зарегистрирован.");

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
            } else
            {
                wrongPasswordLabel.Visible = false;
            }
        }
    }
}
