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
    public partial class CreateBankAccount : Form
    {
        public string newBankAccoutName { get; private set; }

        public CreateBankAccount()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            newBankAccoutName = BankAccountTextBox.Text;
            if (newBankAccoutName == String.Empty || String.IsNullOrWhiteSpace(newBankAccoutName))
            {
                MessageBox.Show("Имя счёта не может быть пустым или состоять из пробелов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
