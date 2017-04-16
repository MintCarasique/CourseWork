namespace Xampple
{
    partial class loginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.JIDbox = new System.Windows.Forms.TextBox();
            this.JIDlabel = new System.Windows.Forms.Label();
            this.Alabel = new System.Windows.Forms.Label();
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswrdLabel = new System.Windows.Forms.Label();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // JIDbox
            // 
            this.JIDbox.Location = new System.Drawing.Point(12, 24);
            this.JIDbox.MaxLength = 30;
            this.JIDbox.Name = "JIDbox";
            this.JIDbox.Size = new System.Drawing.Size(124, 20);
            this.JIDbox.TabIndex = 0;
            // 
            // JIDlabel
            // 
            this.JIDlabel.AutoSize = true;
            this.JIDlabel.Location = new System.Drawing.Point(12, 8);
            this.JIDlabel.Name = "JIDlabel";
            this.JIDlabel.Size = new System.Drawing.Size(56, 13);
            this.JIDlabel.TabIndex = 1;
            this.JIDlabel.Text = "Jabber ID:";
            // 
            // Alabel
            // 
            this.Alabel.AutoSize = true;
            this.Alabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Alabel.Location = new System.Drawing.Point(135, 26);
            this.Alabel.Name = "Alabel";
            this.Alabel.Size = new System.Drawing.Size(22, 16);
            this.Alabel.TabIndex = 2;
            this.Alabel.Text = "@";
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Location = new System.Drawing.Point(154, 24);
            this.ServerNameTextBox.MaxLength = 30;
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(77, 20);
            this.ServerNameTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 63);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(219, 20);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // PasswrdLabel
            // 
            this.PasswrdLabel.AutoSize = true;
            this.PasswrdLabel.Location = new System.Drawing.Point(12, 47);
            this.PasswrdLabel.Name = "PasswrdLabel";
            this.PasswrdLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswrdLabel.TabIndex = 5;
            this.PasswrdLabel.Text = "Password:";
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(12, 102);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(219, 20);
            this.ServerTextBox.TabIndex = 6;
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(12, 86);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(41, 13);
            this.ServerLabel.TabIndex = 7;
            this.ServerLabel.Text = "Server:";
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 340);
            this.Controls.Add(this.ServerLabel);
            this.Controls.Add(this.ServerTextBox);
            this.Controls.Add(this.PasswrdLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.ServerNameTextBox);
            this.Controls.Add(this.Alabel);
            this.Controls.Add(this.JIDlabel);
            this.Controls.Add(this.JIDbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.Text = "Xampple Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox JIDbox;
        private System.Windows.Forms.Label JIDlabel;
        private System.Windows.Forms.Label Alabel;
        private System.Windows.Forms.TextBox ServerNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswrdLabel;
        private System.Windows.Forms.TextBox ServerTextBox;
        private System.Windows.Forms.Label ServerLabel;
    }
}

