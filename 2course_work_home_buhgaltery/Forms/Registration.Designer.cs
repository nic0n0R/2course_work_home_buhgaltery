namespace _2course_work_home_buhgaltery.Forms
{
    partial class Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.registrateBtn = new System.Windows.Forms.Button();
            this.showPassCheckBox = new System.Windows.Forms.CheckBox();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.firstPassTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.repeatPassTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wrongPasswordLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(41, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(236, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // registrateBtn
            // 
            this.registrateBtn.Location = new System.Drawing.Point(41, 284);
            this.registrateBtn.Name = "registrateBtn";
            this.registrateBtn.Size = new System.Drawing.Size(236, 35);
            this.registrateBtn.TabIndex = 2;
            this.registrateBtn.Text = "Зарегистрироваться";
            this.registrateBtn.UseVisualStyleBackColor = true;
            this.registrateBtn.Click += new System.EventHandler(this.registrateBtn_Click);
            // 
            // showPassCheckBox
            // 
            this.showPassCheckBox.AutoSize = true;
            this.showPassCheckBox.Location = new System.Drawing.Point(41, 114);
            this.showPassCheckBox.Name = "showPassCheckBox";
            this.showPassCheckBox.Size = new System.Drawing.Size(114, 17);
            this.showPassCheckBox.TabIndex = 3;
            this.showPassCheckBox.Text = "Показать пароль";
            this.showPassCheckBox.UseVisualStyleBackColor = true;
            this.showPassCheckBox.CheckedChanged += new System.EventHandler(this.showPassCheckBox_CheckedChanged);
            // 
            // roleComboBox
            // 
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] {
            "Родитель",
            "Ребёнок"});
            this.roleComboBox.Location = new System.Drawing.Point(41, 240);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(236, 21);
            this.roleComboBox.TabIndex = 4;
            // 
            // firstPassTextBox
            // 
            this.firstPassTextBox.Location = new System.Drawing.Point(41, 88);
            this.firstPassTextBox.Name = "firstPassTextBox";
            this.firstPassTextBox.Size = new System.Drawing.Size(236, 20);
            this.firstPassTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(38, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // repeatPassTextBox
            // 
            this.repeatPassTextBox.Location = new System.Drawing.Point(41, 165);
            this.repeatPassTextBox.Name = "repeatPassTextBox";
            this.repeatPassTextBox.PasswordChar = '*';
            this.repeatPassTextBox.Size = new System.Drawing.Size(236, 20);
            this.repeatPassTextBox.TabIndex = 0;
            this.repeatPassTextBox.Leave += new System.EventHandler(this.repeatPassTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(38, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Повторите пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(38, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Роль";
            // 
            // wrongPasswordLabel
            // 
            this.wrongPasswordLabel.AutoSize = true;
            this.wrongPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrongPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.wrongPasswordLabel.Location = new System.Drawing.Point(38, 188);
            this.wrongPasswordLabel.Name = "wrongPasswordLabel";
            this.wrongPasswordLabel.Size = new System.Drawing.Size(154, 16);
            this.wrongPasswordLabel.TabIndex = 1;
            this.wrongPasswordLabel.Text = "Пароли не совпадают!";
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 346);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.showPassCheckBox);
            this.Controls.Add(this.registrateBtn);
            this.Controls.Add(this.wrongPasswordLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.repeatPassTextBox);
            this.Controls.Add(this.firstPassTextBox);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registration_FormClosed);
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registrateBtn;
        private System.Windows.Forms.CheckBox showPassCheckBox;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.TextBox firstPassTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox repeatPassTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label wrongPasswordLabel;
        private System.Windows.Forms.Timer timer1;
    }
}