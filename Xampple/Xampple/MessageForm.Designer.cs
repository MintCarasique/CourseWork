namespace Xampple
{
    partial class MessageForm
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
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.InputFieldTextBox = new System.Windows.Forms.TextBox();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.RosterListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(6, 7);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(446, 20);
            this.LogTextBox.TabIndex = 0;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(377, 211);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // InputFieldTextBox
            // 
            this.InputFieldTextBox.Location = new System.Drawing.Point(6, 213);
            this.InputFieldTextBox.Name = "InputFieldTextBox";
            this.InputFieldTextBox.Size = new System.Drawing.Size(365, 20);
            this.InputFieldTextBox.TabIndex = 3;
            // 
            // LogListBox
            // 
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(6, 33);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(446, 173);
            this.LogListBox.TabIndex = 4;
            // 
            // RosterListBox
            // 
            this.RosterListBox.FormattingEnabled = true;
            this.RosterListBox.Location = new System.Drawing.Point(458, 7);
            this.RosterListBox.Name = "RosterListBox";
            this.RosterListBox.Size = new System.Drawing.Size(161, 225);
            this.RosterListBox.TabIndex = 5;
            this.RosterListBox.SelectedIndexChanged += new System.EventHandler(this.RosterListBox_SelectedIndexChanged);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 237);
            this.Controls.Add(this.RosterListBox);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.InputFieldTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.LogTextBox);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox InputFieldTextBox;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.ListBox RosterListBox;
    }
}