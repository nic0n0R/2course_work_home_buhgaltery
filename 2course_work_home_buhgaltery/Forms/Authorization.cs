using _2course_work_home_buhgaltery.Forms;
using _2course_work_home_buhgaltery.Properties;
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

namespace _2course_work_home_buhgaltery
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            nameTextBox.TabIndex = 0;
            passTextBox.TabIndex = 1;
            loginBtn.TabIndex = 2;
            regBtn.TabIndex = 3;
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Hide();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string userName = nameTextBox.Text;
            string password = passTextBox.Text;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите имя пользователя и пароль!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            List<User> users = DataManager.UserDeserialize();


            if (users.Count == 0)
            {
                MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = users.FirstOrDefault(u => u.Name == userName);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (user.Password != password)
            {
                MessageBox.Show("Неверный пароль. Пожалуйста, попробуйте ещё раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MainForm MF = new MainForm(userName);
                MF.Show();
                this.Hide();
            }
        }
    }
}
