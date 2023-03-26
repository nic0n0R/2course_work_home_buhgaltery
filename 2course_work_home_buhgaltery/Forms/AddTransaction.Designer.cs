namespace _2course_work_home_buhgaltery.Forms
{
    partial class AddTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTransaction));
            this.label1 = new System.Windows.Forms.Label();
            this.SumTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.transactionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.warningCatLabel = new System.Windows.Forms.Label();
            this.AddCategoryButton = new System.Windows.Forms.Button();
            this.addCategoryTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AddTransactionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сумма транзакции";
            // 
            // SumTextBox
            // 
            this.SumTextBox.Location = new System.Drawing.Point(15, 77);
            this.SumTextBox.Name = "SumTextBox";
            this.SumTextBox.Size = new System.Drawing.Size(150, 20);
            this.SumTextBox.TabIndex = 1;
            this.SumTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SumTextBox_KeyPress);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(15, 125);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(150, 21);
            this.categoryComboBox.TabIndex = 2;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(12, 109);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(122, 13);
            this.categoryLabel.TabIndex = 0;
            this.categoryLabel.Text = "Категория транзакции";
            // 
            // transactionTypeComboBox
            // 
            this.transactionTypeComboBox.FormattingEnabled = true;
            this.transactionTypeComboBox.Items.AddRange(new object[] {
            "Приход",
            "Расход"});
            this.transactionTypeComboBox.Location = new System.Drawing.Point(15, 25);
            this.transactionTypeComboBox.Name = "transactionTypeComboBox";
            this.transactionTypeComboBox.Size = new System.Drawing.Size(150, 21);
            this.transactionTypeComboBox.TabIndex = 3;
            this.transactionTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Тип транзакции";
            // 
            // warningCatLabel
            // 
            this.warningCatLabel.AutoSize = true;
            this.warningCatLabel.ForeColor = System.Drawing.Color.Red;
            this.warningCatLabel.Location = new System.Drawing.Point(12, 149);
            this.warningCatLabel.Name = "warningCatLabel";
            this.warningCatLabel.Size = new System.Drawing.Size(155, 39);
            this.warningCatLabel.TabIndex = 4;
            this.warningCatLabel.Text = "Ещё нет категорий! \r\nДобавьте сначала хоть одну \r\nкатегорию.";
            // 
            // AddCategoryButton
            // 
            this.AddCategoryButton.Location = new System.Drawing.Point(210, 52);
            this.AddCategoryButton.Name = "AddCategoryButton";
            this.AddCategoryButton.Size = new System.Drawing.Size(152, 35);
            this.AddCategoryButton.TabIndex = 5;
            this.AddCategoryButton.Text = "Добавить категорию";
            this.AddCategoryButton.UseVisualStyleBackColor = true;
            this.AddCategoryButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addCategoryTextBox
            // 
            this.addCategoryTextBox.Location = new System.Drawing.Point(210, 26);
            this.addCategoryTextBox.Name = "addCategoryTextBox";
            this.addCategoryTextBox.Size = new System.Drawing.Size(152, 20);
            this.addCategoryTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Введите название категории";
            // 
            // AddTransactionButton
            // 
            this.AddTransactionButton.Location = new System.Drawing.Point(13, 204);
            this.AddTransactionButton.Name = "AddTransactionButton";
            this.AddTransactionButton.Size = new System.Drawing.Size(152, 39);
            this.AddTransactionButton.TabIndex = 7;
            this.AddTransactionButton.Text = "Добавить транзакцию";
            this.AddTransactionButton.UseVisualStyleBackColor = true;
            this.AddTransactionButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Описание транзакции";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(210, 126);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(152, 20);
            this.DescriptionTextBox.TabIndex = 1;
            // 
            // AddTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 261);
            this.Controls.Add(this.AddTransactionButton);
            this.Controls.Add(this.addCategoryTextBox);
            this.Controls.Add(this.AddCategoryButton);
            this.Controls.Add(this.warningCatLabel);
            this.Controls.Add(this.transactionTypeComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.SumTextBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddTransaction";
            this.Text = "Добавить транзакцию";
            this.Load += new System.EventHandler(this.AddTransaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SumTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox transactionTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label warningCatLabel;
        private System.Windows.Forms.Button AddCategoryButton;
        private System.Windows.Forms.TextBox addCategoryTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddTransactionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescriptionTextBox;
    }
}