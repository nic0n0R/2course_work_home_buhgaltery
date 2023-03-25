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
        public AddTransaction()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // если приход
            if (comboBox2.SelectedIndex == 0)
            {
                categoryLabel.Visible = false;
                categoryTextBox.Visible = false;
            }
            // если расход
            else if (comboBox2.SelectedIndex == 1)
            {
                categoryLabel.Visible = true;
                categoryTextBox.Visible = true;
            }
        }

        private void SumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // проверка на то, что точка вводиться только один раз
            if (ch == '.' && SumTextBox.Text.IndexOf('.') != -1 ) 
            {
                e.Handled = true;
                return;
            }

            // проверка на то, что нельзя ввводить ничего кроме цифр и точки (для сумм с копейками)
            if (!Char.IsDigit(ch) && ch != '.')
            {
                e.Handled = true;
            }
        }
    }
}
