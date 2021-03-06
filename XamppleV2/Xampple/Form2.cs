﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xampple
{
    public partial class LoginForm : Form
    {
        public static LoginForm loginForm = null;
        public LoginForm()
        {
            TopMost = true;
            InitializeComponent();
            loginForm = this;
        }
        public bool isManuallyClosed = false;
        public bool ClosedByLogin = false;
        public bool isSuccessful = false;
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosedByLogin)
            {
                DialogResult ExitDialog = MessageBox.Show("Are you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ExitDialog == DialogResult.Yes)
                {
                    e.Cancel = false;
                    isManuallyClosed = true;
                }
                else
                    e.Cancel = true;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isManuallyClosed)
                Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (EmptyFields())
            {
                DialogResult ErrorDialog = MessageBox.Show("Some fields are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                isManuallyClosed = false;
                ClosedByLogin = true;                
                MainForm.mainForm.StartLogin(UsernameTextBox.Text, ServerTextBox.Text, PasswordTextBox.Text);
            }
        }
        public void ShowMessage()
        {
            DialogResult ErrorDialog = MessageBox.Show("Incorrect JabberID or password!", "Authorization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowErrorMessage(Exception e)
        {
            DialogResult ErrorDialog = MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public bool EmptyFields()
        {
            bool flag = false;
            if ((UsernameTextBox.Text == "") || (ServerTextBox.Text == "") || (PasswordTextBox.Text == ""))
            
                flag = true;
            
            return flag;
        }
        public TextBox GetLogin()
        {
            return UsernameTextBox;
        }
        public TextBox GetServer()
        {
            return ServerTextBox;
        }
        public TextBox GetPassword()
        {
            return PasswordTextBox;
        }
        public LoginForm GetLoginForm()
        {
            return loginForm;
        }    
    }
}
