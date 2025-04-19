namespace BankAccountManagementApp
{
    partial class AccountTransferForm
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
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.fromAccountComboBox = new System.Windows.Forms.ComboBox();
            this.toAccountComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.transferButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(65, 71);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(121, 21);
            this.customerComboBox.TabIndex = 0;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            // 
            // fromAccountComboBox
            // 
            this.fromAccountComboBox.FormattingEnabled = true;
            this.fromAccountComboBox.Location = new System.Drawing.Point(65, 138);
            this.fromAccountComboBox.Name = "fromAccountComboBox";
            this.fromAccountComboBox.Size = new System.Drawing.Size(121, 21);
            this.fromAccountComboBox.TabIndex = 1;
            // 
            // toAccountComboBox
            // 
            this.toAccountComboBox.FormattingEnabled = true;
            this.toAccountComboBox.Location = new System.Drawing.Point(65, 207);
            this.toAccountComboBox.Name = "toAccountComboBox";
            this.toAccountComboBox.Size = new System.Drawing.Size(121, 21);
            this.toAccountComboBox.TabIndex = 2;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(65, 258);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 4;
            // 
            // transferButton
            // 
            this.transferButton.Location = new System.Drawing.Point(65, 319);
            this.transferButton.Name = "transferButton";
            this.transferButton.Size = new System.Drawing.Size(75, 23);
            this.transferButton.TabIndex = 5;
            this.transferButton.Text = "Transfer";
            this.transferButton.UseVisualStyleBackColor = true;
            this.transferButton.Click += new System.EventHandler(this.transferButton_Click);
            // 
            // AccountTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 450);
            this.Controls.Add(this.transferButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.toAccountComboBox);
            this.Controls.Add(this.fromAccountComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Name = "AccountTransferForm";
            this.Text = "AccountTransferForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox fromAccountComboBox;
        private System.Windows.Forms.ComboBox toAccountComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button transferButton;
    }
}