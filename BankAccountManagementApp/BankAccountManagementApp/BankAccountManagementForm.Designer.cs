﻿namespace BankAccountManagementApp
{
    partial class BankAccountManagementForm
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
            this.accountTypeComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewInfoButton = new System.Windows.Forms.Button();
            this.depositButton = new System.Windows.Forms.Button();
            this.withdrawButton = new System.Windows.Forms.Button();
            this.calculateInterestButton = new System.Windows.Forms.Button();
            this.transactionListBox = new System.Windows.Forms.ListBox();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openTransferFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accountTypeComboBox
            // 
            this.accountTypeComboBox.FormattingEnabled = true;
            this.accountTypeComboBox.Location = new System.Drawing.Point(149, 121);
            this.accountTypeComboBox.Name = "accountTypeComboBox";
            this.accountTypeComboBox.Size = new System.Drawing.Size(138, 21);
            this.accountTypeComboBox.TabIndex = 0;
            this.accountTypeComboBox.Text = "Select Account Type";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(150, 198);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 1;
            this.amountTextBox.TextChanged += new System.EventHandler(this.amountTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 75);
            this.label1.MaximumSize = new System.Drawing.Size(0, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bank Account Management Application";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount";
            // 
            // viewInfoButton
            // 
            this.viewInfoButton.Location = new System.Drawing.Point(150, 228);
            this.viewInfoButton.Name = "viewInfoButton";
            this.viewInfoButton.Size = new System.Drawing.Size(75, 23);
            this.viewInfoButton.TabIndex = 4;
            this.viewInfoButton.Text = "View Info";
            this.viewInfoButton.UseVisualStyleBackColor = true;
            this.viewInfoButton.Click += new System.EventHandler(this.viewInfoButton_Click);
            // 
            // depositButton
            // 
            this.depositButton.Location = new System.Drawing.Point(231, 228);
            this.depositButton.Name = "depositButton";
            this.depositButton.Size = new System.Drawing.Size(75, 23);
            this.depositButton.TabIndex = 5;
            this.depositButton.Text = "Deposit";
            this.depositButton.UseVisualStyleBackColor = true;
            this.depositButton.Click += new System.EventHandler(this.depositButton_Click);
            // 
            // withdrawButton
            // 
            this.withdrawButton.Location = new System.Drawing.Point(312, 228);
            this.withdrawButton.Name = "withdrawButton";
            this.withdrawButton.Size = new System.Drawing.Size(75, 23);
            this.withdrawButton.TabIndex = 6;
            this.withdrawButton.Text = "Withdraw";
            this.withdrawButton.UseVisualStyleBackColor = true;
            this.withdrawButton.Click += new System.EventHandler(this.withdrawButton_Click_1);
            // 
            // calculateInterestButton
            // 
            this.calculateInterestButton.Location = new System.Drawing.Point(393, 228);
            this.calculateInterestButton.Name = "calculateInterestButton";
            this.calculateInterestButton.Size = new System.Drawing.Size(108, 23);
            this.calculateInterestButton.TabIndex = 7;
            this.calculateInterestButton.Text = "Calculate Interest";
            this.calculateInterestButton.UseVisualStyleBackColor = true;
            this.calculateInterestButton.Click += new System.EventHandler(this.calculateInterestButton_Click);
            // 
            // transactionListBox
            // 
            this.transactionListBox.FormattingEnabled = true;
            this.transactionListBox.Location = new System.Drawing.Point(150, 280);
            this.transactionListBox.Name = "transactionListBox";
            this.transactionListBox.Size = new System.Drawing.Size(359, 95);
            this.transactionListBox.TabIndex = 8;
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(311, 121);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(121, 21);
            this.customerComboBox.TabIndex = 9;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(447, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Create";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openTransferFormButton
            // 
            this.openTransferFormButton.Location = new System.Drawing.Point(150, 405);
            this.openTransferFormButton.Name = "openTransferFormButton";
            this.openTransferFormButton.Size = new System.Drawing.Size(100, 23);
            this.openTransferFormButton.TabIndex = 15;
            this.openTransferFormButton.Text = "Money Transfer";
            this.openTransferFormButton.UseVisualStyleBackColor = true;
            this.openTransferFormButton.Click += new System.EventHandler(this.openTransferFormButton_Click);
            // 
            // BankAccountManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(676, 513);
            this.Controls.Add(this.openTransferFormButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.transactionListBox);
            this.Controls.Add(this.calculateInterestButton);
            this.Controls.Add(this.withdrawButton);
            this.Controls.Add(this.depositButton);
            this.Controls.Add(this.viewInfoButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.accountTypeComboBox);
            this.Name = "BankAccountManagementForm";
            this.Text = "Bank Account Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox accountTypeComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button viewInfoButton;
        private System.Windows.Forms.Button depositButton;
        private System.Windows.Forms.Button withdrawButton;
        private System.Windows.Forms.Button calculateInterestButton;
        private System.Windows.Forms.ListBox transactionListBox;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button openTransferFormButton;
    }
}

