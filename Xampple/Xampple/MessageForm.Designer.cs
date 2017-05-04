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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(6, 29);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(446, 20);
            this.LogTextBox.TabIndex = 0;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(377, 233);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // InputFieldTextBox
            // 
            this.InputFieldTextBox.Location = new System.Drawing.Point(6, 235);
            this.InputFieldTextBox.Name = "InputFieldTextBox";
            this.InputFieldTextBox.Size = new System.Drawing.Size(365, 20);
            this.InputFieldTextBox.TabIndex = 3;
            // 
            // LogListBox
            // 
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(6, 55);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(446, 173);
            this.LogListBox.TabIndex = 4;
            // 
            // RosterListBox
            // 
            this.RosterListBox.FormattingEnabled = true;
            this.RosterListBox.Location = new System.Drawing.Point(458, 29);
            this.RosterListBox.Name = "RosterListBox";
            this.RosterListBox.Size = new System.Drawing.Size(161, 225);
            this.RosterListBox.TabIndex = 5;
            this.RosterListBox.SelectedIndexChanged += new System.EventHandler(this.RosterListBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 261);
            this.Controls.Add(this.RosterListBox);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.InputFieldTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MessageForm";
            this.Text = "Xampple";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox InputFieldTextBox;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.ListBox RosterListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}